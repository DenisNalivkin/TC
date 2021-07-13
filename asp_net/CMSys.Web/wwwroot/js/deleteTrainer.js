var allButtonsDeleteTrainer = document.querySelectorAll('.ButtonDeleteTrainer');
var mainElem = null;
var newElem = null;
var trainerForDelete = null;
var stringWithElemForTrainersPage = null;
var dataTrainers = null;
var stringWithElemForEditTrainer = null;
var buttonUpdateTrainer = null;
var buttonEditTrainerId = null;
var buttonForContor1 = null;
var buttonDeleteTrainer = null;
var buttonForContor2 = null;




allButtonsDeleteTrainer.forEach(item => {
    item.addEventListener( 'click', e => { 
        var _trainerForDelete =  e.target.value;
        $.post('/Trainer/DeleteTrainer', $.param({ trainerForDelete: _trainerForDelete }, true), function() {
            const _request = new XMLHttpRequest();
            const _url ="http://localhost:61558/Trainer/getDataTrainerGroup";
            _request.onreadystatechange = function() 
            {
                if ( _request.readyState === 4) 
                { 
                    dataTrainerGroup = JSON.parse(_request.response);
                    
                    const request = new XMLHttpRequest();
                    const url ="http://localhost:61558/Trainer/getDataTrainers";
                    request.onreadystatechange = function() 
                    {
                        if (request.readyState === 4) 
                        {
                            document.querySelectorAll('.divContainerForTrainerInformation').forEach(e => e.remove());
                            dataTrainers = JSON.parse(request.response);
                            const amountTrainers = Object.keys(dataTrainers);            
                            mainElem = document.querySelector(".containerForTrainerList");
                    
                            for(var n = 0; n <amountTrainers.length; n++)
                            {
                                newElem = document.createElement("div");
                                newElem.setAttribute("class", "divContainerForTrainerInformation");
                                mainElem.appendChild(newElem);
                                newElem.insertAdjacentHTML('beforeEnd', `
                                    <div class="divContainerForTrainerInformation">
                                    <div class="firstItemDivContainerForTrainerInformation">
                                        <img class="imgShowTrainerlist" src="data:image/gif;base64,${dataTrainers[n]['user']['photo']}" width="35%" height="75%" alt="trainer" />
                                        <p class="pTrainerNameShowTrainerlist"> ${dataTrainers[n]['user']['fullName']} </p>
                                    </div>                 
                                    <div class="itemsDivContainerForTrainerInformation">
                                        <p class="pString"> ${dataTrainers[n]['trainerGroup']['name']}  </p>
                                    </div>
                                    <div class="itemsDivContainerForTrainerInformation">
                                        <p class="pString"> ${dataTrainers[n]['visualOrder']}  </p>
                                    </div>
                                    <div class="lastItemDivContainerForTrainerInformation">
                                        <button type="button" class="ButtonEditTrainer" value=" ${dataTrainers[n]['user']['fullName']}" id="ButtonEditTrainerId${n}">
                                            Edit  trainer
                                        </button>
                                        <button type="button" class="ButtonDeleteTrainer" value="${dataTrainers[n]['user']['fullName']}" id="ButtonDeleteTrainerId${n}">
                                            Delete course
                                        </button>
                                    </div>
                                `)

                                buttonEditTrainerId = "ButtonEditTrainerId"+ n.toString();
                                buttonForContor1 = document.getElementById(buttonEditTrainerId);                                                       
                                buttonForContor1.addEventListener( 'click', e => { 
                                    var trainerForEdit =  e.target.value;
                                    allFunctions.addHtmlElementsEditTrainerAndAddEventForButtonUpdate(dataTrainerGroup,trainerForEdit,mainElem,newElem,stringWithElemForEditTrainer,buttonUpdateTrainer);                                                                                                                                    
                                })

                                buttonDeleteTrainer = "ButtonDeleteTrainerId" + n.toString();
                                buttonForContor2 = document.getElementById(buttonDeleteTrainer);
                                buttonForContor2.addEventListener( 'click', e => { 
                                  
                                    var trainerForDelete2 =  e.target.value;                               
                                    $.post('/Trainer/DeleteTrainer', $.param({ trainerForDelete: trainerForDelete2 }, true), function() {
                                        const request = new XMLHttpRequest();
                                        const url ="http://localhost:61558/Trainer/getDataTrainers";
                                        request.onreadystatechange = function() 
                                        {
                                            if (request.readyState === 4) 
                                            {
                                                dataTrainers = JSON.parse(request.response);
                                                allFunctions.addHtmlElementsDeleteTrainerAndAddEventListenerButtonEditTrainerButtonDeleteTrainer(dataTrainers,dataTrainerGroup,amountTrainers,mainElem,newElem,buttonEditTrainerId,buttonForContor1,buttonDeleteTrainer,buttonForContor2);    
                                            }
                                        }
                                        request.open('GET',url);
                                        request.send();                                       
                                    });
                               })
                           }
                        }               
                    }  
                    request.open('GET',url);
                    request.send();
               }     
            }  
            _request.open('GET',_url);
            _request.send();    
        });           
    })
})




  
