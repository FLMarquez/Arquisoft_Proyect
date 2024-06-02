let myChartState;
let myChartProjectType;



function createProjectStateChart(chartElement, jsonData, chartOptions, dataKeys, colorMap) {
    const ctx = chartElement.getContext('2d');

    function processData(jsonData, dataKeys) {
        const data = {};
        jsonData.forEach(item => {
            const date = item.date.split('T')[0];
            if (!data[date]) {
                const initialData = {};
                dataKeys.forEach(key => initialData[key] = 0);
                data[date] = initialData;
            }
            data[date][item.status.toLowerCase()]++;
        });
        return data;
    }

    function updateChart() {
        const startDate = document.getElementById('startDate').value;
        const endDate = document.getElementById('endDate').value;
        const processedData = processData(jsonData, dataKeys);
        const labels = Object.keys(processedData).filter(label => label >= startDate && label <= endDate);

        if (labels.length === 0) {
            myChartState.data.labels = [];
            myChartState.data.datasets = [];
            myChartState.update();
            return;
        }

        const datasets = dataKeys.map(status => ({
            label: status.charAt(0).toUpperCase() + status.slice(1),
            data: labels.map(label => processedData[label][status]),
            backgroundColor: colorMap[status].background,
            borderColor: colorMap[status].border,
            borderWidth: 1
        }));

        const newData = { labels, datasets };
        myChartState.data = newData;
        myChartState.update();
    }

    myChartState = new Chart(ctx, {
        type: 'bar',
        data: {},
        options: chartOptions
    });

    updateChart();

    const startDateInput = document.getElementById('startDate');
    const endDateInput = document.getElementById('endDate');

    startDateInput.addEventListener('change', updateChart);
    endDateInput.addEventListener('change', updateChart);
}

function createProjectTypeChart(chartElement, jsonData, chartOptions) {
    const ctx = chartElement.getContext('2d');

    function processData(jsonData) {
        const data = {};
        jsonData.forEach(item => {
            const date = item.date.split('T')[0];
            if (!data[date]) {
                data[date] = {};
            }
            const projectType = item.type;
            data[date][projectType] = (data[date][projectType] || 0) + 1;
        });
        return data;
    }

    function updateProjectTypeChart() {
        const startDateInput = document.getElementById('startDateType');
        const startDate = startDateInput ? startDateInput.value : '';
        const endDate = document.getElementById('endDateType').value;
        const processedData = processData(jsonData);
        const labels = Object.keys(processedData).filter(label => label >= startDate && label <= endDate);

        if (labels.length === 0) {
            myChartProjectType.data.labels = [];
            myChartProjectType.data.datasets = [];
            myChartProjectType.update();
            return;
        }

        const datasets = Object.keys(processedData[labels[0]]).map(type => ({
            label: type,
            data: labels.map(label => processedData[label][type] || 0),
            backgroundColor: getRandomColor(),
            borderColor: getRandomColor(),
            borderWidth: 1
        }));

        function getRandomColor() {
            // Genera componentes de color en el rango pastel (valores entre 150 y 250)
            const r = Math.floor(Math.random() * 100) + 150;
            const g = Math.floor(Math.random() * 100) + 150;
            const b = Math.floor(Math.random() * 100) + 150;

            // Convierte los componentes de color a hexadecimal y los concatena
            return '#' + r.toString(16) + g.toString(16) + b.toString(16);
        }


        const newData = { labels, datasets };
        myChartProjectType.data = newData;
        myChartProjectType.update();
    }

    myChartProjectType = new Chart(ctx, {
        type: 'bar',
        data: {},
        options: chartOptions
    });

    updateProjectTypeChart();

    // Agregar event listeners
    const startDateInput = document.getElementById('startDateType');
    const endDateInput = document.getElementById('endDateType');

    startDateInput.addEventListener('change', updateProjectTypeChart);
    endDateInput.addEventListener('change', updateProjectTypeChart);
}
function getAmountTimeChart(chartElement, jsonData, chartOptions) {
    const ctx = chartElement.getContext('2d');
    let myChartAmountTime; // Corregir el nombre de la variable del gráfico

    function processData(jsonData) {
        const data = {};
        jsonData.forEach(item => {
            const date = item.date.split('T')[0];
            if (!data[date]) {
                data[date] = {};
            }
            // Aquí debes asignar a una clave adecuada, no a `amount`
            const amount = item.amount;
            data[date][amount] = (data[date][amount] || 0) + 1;
        });
        return data;
    }

  