const director = (function () {
    
    //private members
    const table_id = '#jobs_table';
    
    function ctor() {
        $(document).ready(function () {
            render();
            setInterval(render, 3000);
        })
    }
    
    function render() {
        const data = getData();

        $(table_id).empty();

        generateHeaders();
        
        $.each(data, function(i, item) {
            generateRow(item).appendTo(table_id);
        });
    }

    function getData() {
        let result = null;

        $.ajax({
            type: "Get",
            url: 'Jobs/GetDataItems',
            async: false,
            dataType: "json",
            success: function(data) {
                // Run the code here that needs
                //    to access the data returned
                result = data;
            },
            error: function() {
                alert('Error occured');
            }
        });
        return result;
    }

    function generateHeaders() {
        $(table_id).append(
            $('<tr>').append(
                $('<td>').text("Name"),
                $('<td>').text("Status"),
                $('<td>').text("Details")
        ));
    }
    
    function generateRow(item) {
        return $('<tr>').append(
            $('<td>').text(item.Name),
            $('<td>').text(item.Status),
            $('<td>').html('<a href="/Jobs/Details?jobId='+item.Id+'"> Details</a>')
        )
    }
    
    return{
        //return public func
        render: render,
        ctor: ctor,
    }
    
    
})();

director.ctor();