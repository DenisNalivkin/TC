var allButtonsEditTrainer = document.querySelectorAll('.ButtonEditTrainer');
var dataCourses = null;
var dataTrainerGroup = null;
var newElem = null;
var mainElem = null;
var stringWithElemForEditTrainer = "";
var arrayTrainerGroupName = [];
var buttonUpdateTrainer = null;


const _request = new XMLHttpRequest();
const _url ="http://localhost:61558/Trainer/getDataTrainerGroup";
_request.onreadystatechange = function() 
{
    if ( _request.readyState === 4) 
    { 
        dataTrainerGroup = JSON.parse(_request.response);

        allButtonsEditTrainer.forEach(item => {
            item.addEventListener( 'click', e => { 
                var trainerForEdit =  e.target.value;
                
                const request = new XMLHttpRequest();
                const url ="http://localhost:61558/Trainer/getDataCourses";
                request.onreadystatechange = function() 
                {
                    if (request.readyState === 4) 
                    { 
                        document.querySelectorAll('.divWithData2').forEach(e => e.remove());              
                        document.querySelectorAll('.containerForTrainerList').forEach(e => e.remove());
                        document.querySelectorAll('.divContainerStringShowTrainerlist').forEach(e => e.remove());
                        document.querySelectorAll('.divLine').forEach(e => e.remove());
                        document.querySelectorAll('.divContainerForTrainerInformation').forEach(e => e.remove());
        
                        dataCourses = JSON.parse(request.response);
                        mainElem = document.querySelector(".divMainContent");
        
                        arrayTrainerGroupName = [];
                        for(var x = 0; x < dataTrainerGroup.length; x ++)
                        {
                            arrayTrainerGroupName.push(dataTrainerGroup[x]['name']);
                        }      
                        for(var n = 0; n <arrayTrainerGroupName.length; n++)
                        {   
                            stringWithElemForEditTrainer += `<option> ${arrayTrainerGroupName[n]} </option> `;                   
                        }
           
                        newElem = document.createElement("div");
                        newElem.setAttribute("class", "divWithData");
                        mainElem.appendChild(newElem);
                        newElem.insertAdjacentHTML('afterbegin', `
                                <div class="divForHeading">
                                    <p class="h2Course">
                                        Update Trainer: ${trainerForEdit}
                                    </p>
                                </div>                                
                                    <div class="divForContainerUpdateTrainer">
                                        <div class="containerUpdateTrainer">
                                            <div class="containerUpdateTrainer2">                                                        
                                                <div class="itemsUpdateTrainer">
                                                    <label for="selectTrainersGroupId" class="labelUpdateTrainer"> Trainer group </label>
                                                    <br />
                                                    <select  class="customform-control" id="selectTrainersGroupId">
                                                        ${stringWithElemForEditTrainer}                                                    
                                                    </select>
                                                </div>
                                                <div class="itemsUpdateTrainer">
                                                    <label for="Order" class="labelUpdateTrainer"> Order </label>
                                                    <br />
                                                    <input for="Order" class="customform-control" id="inputOrderId" />
                                                    <span class="spanForUpdateTrainer" style="color:red"; id="spanOrderId">  </span>
                                                </div>
                                                <div class="itemsUpdateTrainer">
                                                    <label for="textAreaId" class="labelUpdateTrainer"> Description </label>
                                                    <br />
                                                    <textarea  class="customform-control" maxlength="4000" id="textAreaId"></textarea>
                                                    <span class="spanForUpdateTrainer" style="color:red"; id="spanDescriptionId"> </span>                                                    
                                                </div>
                                                <div class="divForButtonUpdate">
                                                    <button class="btn btn-primary button3" type="submit" id="buttonUpdateId"> Update </button>
                                                </div>
                                            </div>
                                            <div class="divForABackTolist">
                                                <a class="aBackToList" href="http://localhost:61558/Trainer/ShowTrainerList"> Back to list </a>
                                            </div>                                                                                                                                                     
                                        </div>
                                    </div>
                                         
                        `);

                        buttonUpdateTrainer = document.getElementById('buttonUpdateId');
                        buttonUpdateTrainer.addEventListener( 'click', e => {
                            var elemSelectTrainersGroup = document.getElementById('selectTrainersGroupId');
                            var elemInputOrder = document.getElementById('inputOrderId');
                            var elemTextArea = document.getElementById('textAreaId');
                            var elemSpan = null;                       
                            var intValueInputOrder =  Number(elemInputOrder.value);                              
                            var resultCheckInt = Number.isInteger(intValueInputOrder); 
                                                                          
                            if(intValueInputOrder  < 0 )
                            {
                                elemSpan = document.getElementById('spanOrderId');  
                                elemSpan.innerHTML = "Error! Use an integer that must be at least 0!";                               
                            }
                            else if(resultCheckInt == false)
                            {
                                elemSpan = document.getElementById('spanOrderId');  
                                elemSpan.innerHTML = "Error! Use an integer that must be at least 0!";  
                            }
                            else if(elemTextArea.value.length > 4000)
                            {
                                elemSpan = document.getElementById('spanDescriptionId');  
                                elemSpan.innerHTML =  "Error! The text size must be no more than 4000 characters!";  
                            }                     
                            else
                            {
                                elemSpan = document.getElementById('spanOrderId');  
                                elemSpan.innerHTML = "";
                                elemSpan = document.getElementById('spanDescriptionId');  
                                elemSpan.innerHTML = "";                                                                                                                                                   
                                var allDataForUpdateTrainer = `${trainerForEdit}/${elemSelectTrainersGroup.value}/${elemInputOrder.value}/${elemTextArea.value}`;
                                $.get('/Trainer/UpdateTrainer', $.param({ allDataForUpdateTrainer: allDataForUpdateTrainer }, true), function() {                                        
                                });                                                                                                            
                            }                                                         
                        })                    
                    }     
                }  
                request.open('GET',url);
                request.send();                
            })
        })                        
    }     
}  
_request.open('GET',_url);
_request.send();    











