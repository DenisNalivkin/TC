var allButtonsEditTrainer = document.querySelectorAll('.ButtonEditTrainer');
var dataCourses = null;
var dataTrainerGroup = null;
var newElem = null;
var mainElem = null;
var stringWithElemForEditTrainer = "";
var arrayTrainerGroupName = [];
var buttonUpdateTrainer = null;


const request = new XMLHttpRequest();
const url ="http://localhost:61558/Trainer/getDataTrainerGroup";
request.onreadystatechange = function() 
{
    if ( request.readyState === 4) 
    { 
        dataTrainerGroup = JSON.parse(request.response);

        allButtonsEditTrainer.forEach(item => {
            item.addEventListener( 'click', e => { 
                var trainerForEdit =  e.target.value;                  
                allFunctions.addHtmlElementsEditTrainerAndAddEventForButtonUpdate(dataTrainerGroup,trainerForEdit,mainElem,newElem,stringWithElemForEditTrainer,buttonUpdateTrainer);                                                   
            })
        })                        
    }     
}  
request.open('GET',url);
request.send();    













