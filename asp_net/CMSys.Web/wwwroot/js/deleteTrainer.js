var allButtonsDeleteTrainer = document.querySelectorAll('.ButtonDeleteTrainer');
var mainElem = null;
var trainerForDelete = null;
var stringWithElemForTrainersPage = null;
var dataTrainers = null;



allButtonsDeleteTrainer.forEach(item => {
    item.addEventListener( 'click', e => { 
        var _trainerForDelete =  e.target.value;
        $.post('/Trainer/DeleteTrainer', $.param({ trainerForDelete: _trainerForDelete }, true), function() {
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
                                <button type="button" class="ButtonEditTrainer" value=" ${dataTrainers[n]['user']['fullName']}" id="ButtonEditTrainerId">
                                    Edit  trainer
                                </button>
                                <button type="button" class="ButtonDeleteTrainer" value="${dataTrainers[n]['user']['fullName']}" id="ButtonDeleteTrainerId">
                                    Delete course
                                </button>
                            </div>
                        `)
                                                              
                    }                                     
                }     
            }  
            request.open('GET',url);
            request.send();     
        });           
    })
})

