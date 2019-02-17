var Cijena;
var Naziv;
var Sifra;
var proizvodi;




GetData();


function GetData(){
    $.getJSON("http://localhost:50854/api/products",function(){})
    .done(function(data) {
        console.log(data);
        proizvodi = data;
        console.log("Proizvodi:",proizvodi);
    }
    )
}


function ShowData(){

}