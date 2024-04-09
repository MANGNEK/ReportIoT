// Khai báo biến myChart mà không khởi tạo biểu đồ ngay lập tức
var myChart;

// Hàm cập nhật dữ liệu và vẽ biểu đồ
function fetchDataAndUpdateChart() {
    fetch('/Home/Data')
        .then(response => response.json())
        .then(data => {
            console.log(data);
            // Cập nhật dữ liệu nhiệt độ
            document.getElementById('temperatureValue').textContent = data.temperture;
            document.getElementById('GasValue').textContent = data.gasdata;
            document.getElementById('HumidityValue').textContent = data.humidity;
            document.getElementById('RaindropValue').textContent = data.raindrop;

            // Nếu biểu đồ chưa được khởi tạo, khởi tạo nó
            if (!myChart) {
                initializeChart();
            }

            // Cập nhật dữ liệu cho biểu đồ
            updateChartData(data);
        })
        .catch(error => {
            console.error('Error fetching data:', error);
        });
}

// Hàm khởi tạo biểu đồ
function initializeChart() {
    // Lấy context của canvas để vẽ biểu đồ
    var ctx = document.getElementById('chart-line-tasks').getContext('2d');

    // Dữ liệu mẫu cho biểu đồ đường
    var data = {
        labels: [],
        datasets: [{
            label: 'Temperature',
            data: [],
            fill: false,
            borderColor: 'rgb(75, 192, 192)',
            tension: 0.1
        },
        {
            label: 'Humidity',
            data: [],
            fill: false,
            borderColor: 'rgb(255, 99, 132)',
            tension: 0.1
        }]
    };

    // Cấu hình biểu đồ
    var config = {
        type: 'line',
        data: data,
    };

    // Tạo biểu đồ
    myChart = new Chart(ctx, config);
}

// Hàm cập nhật dữ liệu cho biểu đồ
function updateChartData(data) {
    myChart.data.labels.push(new Date().toLocaleTimeString());
    myChart.data.datasets[0].data.push(data.temperture);
    myChart.data.datasets[1].data.push(data.humidity);

    // Giới hạn số lượng điểm trên biểu đồ để giữ nó trong khoảng nhất định
    const maxDataPoints = 7;
    if (myChart.data.labels.length > maxDataPoints) {
        myChart.data.labels.shift();
        myChart.data.datasets[0].data.shift();
        myChart.data.datasets[1].data.shift();
    }

    myChart.update();
}

// Lặp lại việc fetch dữ liệu và cập nhật biểu đồ sau mỗi 2 giây
setInterval(fetchDataAndUpdateChart, 2000);
