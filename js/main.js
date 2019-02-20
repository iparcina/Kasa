var Cijena;
var Naziv;
var Sifra;
var proizvodi;
var id;


GetData();

$( "#addProduct" ).click(function() {

  $("#form1").toggle();
  
});
$( "#deleteProduct" ).click(function() {

  $("#form2").toggle();
  
});


function GetData(){
    $.getJSON("http://localhost:50854/api/products",function(){})
    .done(function(data) {
        proizvodi = data;
        WriteData();
    }
    )
}

function WriteData(){
    
    $.each(proizvodi, function (index, item) {
        
        var eachrow = "<tr>"
                    + "<td>" + item.Sifra + "</td>" 
                    + "<td>" + item.Naziv + "</td>" 
                    + "<td>" + item.Cijena + ",00 kn </td>" 
                    + "</tr>";
        $('#tbody').append(eachrow);
        console.log(item);
   });
}
   
 //
  function getFormData(dom_query){
    var out = {};
    var s_data = $(dom_query).serializeArray();
    for(var i = 0; i<s_data.length; i++){
        var record = s_data[i];
        out[record.name] = record.value;
    }
    return out;
}


  $("#submit").click(function(){
    var data1 = (getFormData('#form1'));
    $.post("http://localhost:50854/api/addproducts",
        {
            Sifra : data1.Sifra,
            Naziv : data1.Naziv,
            Cijena : data1.Cijena,
            Kolicina: 0

        },
    function(msg){
      alert("Proizvod je dodan!");
    });
  });

function GetIdByName(){
  var podaci = (getFormData('#form2'));
  var delpro = podaci.Name;
  GetData();
  $.each(proizvodi,function(index,item){
    if(item.Naziv== delpro)
    {
      id = item.ID_proizvod;
    }
    
  })
  
  
}


//izbrisi proizvod
$("#submit1").click(function(){
  var data2 = (getFormData('#form2'));
  GetIdByName();
  console.log( "Podaci iz metode izbrisi proizvod:"+data2);
  $.ajax({
    type: "DELETE",
    url: "http://localhost:50854/api/deleteproduct/"+id,
    data: "name=8",
    success: function(msg){
        alert("Proizvod izbrisan" );
    }
});
$('#data tbody').empty();
}); 
