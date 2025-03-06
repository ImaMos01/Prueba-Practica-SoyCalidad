async function getProgramas() {
    //obtenemos todos los programas disponibles
    try {
        await $.ajax({
            url: '/Programas',
            type: 'GET',
            dataType: "json",
            success: function (data) {
                $('#programasSelect').empty();

                data.forEach(function (item) {
                    $('#programasSelect').append('<option value="' + item.idPrograma + '">' + item.programa + '</option>');
                });
                $('#programasSelect').val(1); //dejamos Grado en Enfermería por defecto
            },
            error: function (status, error) {
                console.error("Error AJAX: " + status + ", " + error);
            }

        });
    } catch (error) {
        console.error(error);
    }
}

function convertirfecha(fecha) {
    const [year, month, day] = fecha.split('T')[0].split('-');

    // Devolvemos la fecha en formato 'dd/mm/yyyy'
    return `${day}/${month}/${year}`;
}

$("#programasSelect").on('change', async function () {
    try {
        let value = $(this).val();
        await $.ajax({
            url: '/Asignaturas',
            type: 'GET',
            data: {
                id: value
            },
            dataType: "json",
            success: function (data) {
                $('#headBody').empty();

                data.forEach(function (item) {
                    let row = $('<tr>');

                    let newFecha = convertirfecha(item.fechaAlta);
                    row.append($('<td>').text(item.asignatura || ""));   
                    row.append($('<td>').text(item.programa || ""));   
                    row.append($('<td>').text(item.esOpcional ? "Si" : "No"));    
                    row.append($('<td>').text(item.tieneDocencia ? "Si" : "No"));   
                    row.append($('<td>').text(newFecha)); 

                    $('#headBody').append(row);

                });
            },
            error: function (status, error) {
                console.error("Error AJAX: " + status + ", " + error);
            }

        });
    } catch (error) {
        console.error(error);
    }
})

document.addEventListener('DOMContentLoaded', async function () {
    try {
        await getProgramas();
    }
    catch (error) {
        console.error(error);
    }
});
