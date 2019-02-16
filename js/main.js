GetData();

function GetData(){
    $.getJSON(" http://localhost:50854/api/products",function(){})
    .done(function(data) {
      console.log(data);
      
    } )
    }