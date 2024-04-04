
setInterval(function () {
    fetch('/Home/Data')
        .then(response => response.json())
        .then(data => {
            console.log(data);
            // Cập nhật dữ liệu nhiệt độ
            document.getElementById('temperatureValue').textContent = data.temperture;
            document.getElementById('GasValue').textContent = data.gasdata;
            document.getElementById('HumidityValue').textContent = data.humidity;
            document.getElementById('RaindropValue').textContent = data.raindrop;
            // Cập nhật dữ liệu khí
        })
        .catch(error => {
            console.error('Error fetching data:', error);
        });
}, 2000);


