var allButtons = document.querySelectorAll('.btn');
var dataCourses = null;
var newElem = null;
var  containerForCourses = null;

allButtons.forEach(item => {
    item.addEventListener('click', e => { 
        var courseName =  e.target.value.split('/courseData')[0];
        var courseDescription =  e.target.value.split('/courseData')[1].replace('/','');
        var courseGroupName = e.target.value.split('/courseData')[3].replace('/','');
        var courseTypeName = e.target.value.split('/courseData')[4].replace('/','');

        document.querySelectorAll('.divForHeading').forEach(e => e.remove());
        document.querySelectorAll('.divPanelFilters').forEach(e => e.remove());
        document.querySelectorAll('.itemsSelectTypesPanelFilters').forEach(e => e.remove())    
        document.querySelectorAll('.itemsContainerForCourses').forEach(e => e.remove());

        const request = new XMLHttpRequest();
        const url ="http://localhost:61558/Course/getDataCourses";
        request.onreadystatechange = function() 
        {
            if (request.readyState === 4) 
            {      
                containerForCourses = document.querySelector("div.containerForCourses");
                dataCourses = JSON.parse(request.response);
                const amountCourses = Object.keys(dataCourses);

                containerForCourses = document.querySelector("div.containerForCourses");       
                newElem = document.createElement("div");
                newElem.setAttribute("class", "itemsContainerForCourses","id", "itemsContainerForCoursesId");
                containerForCourses.appendChild(newElem); 
                              
                newElem.insertAdjacentHTML('afterbegin', `           
                    <div class="divNameCourse" id="divNameCourseId">
                        <p class="pNameCourse" id="pNameCourseId">${courseName}</p>
                        <br />
                        <button type="button" class="btn button1"> ${courseGroupName} </button>
                        <button type="button" class="btn button2"> ${courseTypeName} </button>
                    </div>
                    <div class="divCourseDescription">
                        <br />
                        <br />
                        <br />
                        <p class="pStringCourseDescription"> ${courseDescription} </p>   
                    </div>
                    <div class="divInformationCourse">                     
                    <div class="containerAllTrainersInMoreInforamtion" id="containerAllTrainersInMoreInforamtionId">
                        <div class="itemsContainerAllTrainersInMoreInforamtion"> <p class="pStringCourseDescription">   Trainers: </p>  </div>                       
                    </div>                                      
                    </div>
                    <br /> 
                    <br />
                    <a class="aBackToList" href="http://localhost:61558/Course/ShowAllCourses"> Back to list</a> 
                    <div class="modal" id="myModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <!-- Modal Header -->
                                <div class="modal-header">
                                    <h4 class="modal-title"> </h4>
                                    <button type="button" class="close" data-dismiss="modal">×</button>
                                </div>
                                <!-- Modal body -->
                                <div>
                                    <img id="imgTrainerLocation" class="imgTrainerLocation" width="25%" height="35%" atl="trainer2"/>                                
                                    <div class="modal-body"></div>                                            
                                </div>                                       
                                <!-- Modal footer -->
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
                                  
                `); 
         
                newElem = document.getElementById('containerAllTrainersInMoreInforamtionId');   
                for(let i = 0; i < amountCourses.length;i++)
                {
                    if(dataCourses[i]['name'].toLowerCase().split(' ').join('') == courseName.toLowerCase().split(' ').join(''))
                    {
                        for(let j = 0; j < dataCourses[i]['trainers'].length; j ++)
                        {
                            newElem.insertAdjacentHTML('beforeend', `
                            <div class="itemsContainerAllTrainersInMoreInforamtion"> <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal" value="${dataCourses[i]['trainers'][j]['trainer']['description']} / ${dataCourses[i]['trainers'][j]['trainer']['user']['fullName']} ///photoTrainer///p ${dataCourses[i]['trainers'][j]['trainer']['user']['photo']} "> ${dataCourses[i]['trainers'][j]['trainer']['user']['fullName']}  </button>   </div>     
                            `)
                            newElem.addEventListener('click', function(e) {

                                var trainerFullName =  e.target.value.split('/')[1];
                                var trainerDescription = e.target.value.split('/')[0];
                                var photoTrainer = e.target.value.split('///photoTrainer///p')[1];
                                var img = document.getElementById('imgTrainerLocation')
                                                   
                                var h4ModalTitle =  document.getElementsByClassName('modal-title');
                                h4ModalTitle[0].innerHTML =  trainerFullName;      
                                img.setAttribute('src',`data:image/gif;base64, ${photoTrainer} `);                                
                                var divModalBody =  document.getElementsByClassName('modal-body');
                                divModalBody[0].innerHTML =  trainerDescription;       
                            });                           
                        }
                    }
                }
          }
        }  
        request.open('GET',url);
        request.send();            
    })
  })
