var ServiceProxy;
if (window.addEventListener) {
    window.addEventListener("load", doLoad, false);
}
else
    if (window.attachEvent) {
        window.attachEvent("onload", doLoad);
    } else
        if (window.onLoad) {
            window.onload = doLoad;
        }


function doLoad() 
{
   
    ServiceProxy = new WCFService.IDBService();
  
   
     
}

function Get_Click() {

    ServiceProxy.GetRecords(OnGetRecords, OnFail, null);
 }


function OnGetRecords(result) {
 
    var array = result.split("!");
    var html = "";

    for (i = 0; i < array.length-1; i++) {
        var record = JSON.parse(array[i]);
        html += "<input id='id_" + record.id + "' value='" + record.id + "'/>";
        html += "<input id='id_" + record.id + "_fname' value='" + record.fname + "'/>";
        html += "<input id='id_" + record.id + "_lname' value='" + record.lname + "'/>";
        html += "<input type='button' id='id_" + record.id + "_submit' value='Submit' onclick='Submit_Click(this)' />";
        html += "</br>";
         
    
    }
   
        Record.innerHTML = html;
}


function Submit_Click(element) {
    var array;
    var id, fname, lname;    
    array = (element.id).split("_");
    id = array[1];
    fname = document.getElementById("id_" + id + "_fname").value;
    lname = document.getElementById("id_" + id + "_lname").value;

    var record = new Object();
    record.id = id;
    record.fname = fname;
    record.lname = lname;

    var jsonstring = JSON.stringify(record);

    ServiceProxy.SaveChanges(jsonstring);
}




function OnFail() 
{
    alert("hmm.."); 
}





