/// Functions for ShowAllCourses page
function addDataToPageAFterUseFilters(newElem,containerForCourses,dataCourses,amountCourses,valueSelect,typeSelect)
{
    if(typeSelect =='All groups')
    {
        for(let i = 0; i < amountCourses.length;i++)
        {
            if(valueSelect == typeSelect)// если в фильтре выбрали  все курсы
            {
                for(let j = 0; j < amountCourses.length;j++)
                {                   
                    newElem = document.createElement("div");
                    newElem.setAttribute("class", "itemsContainerForCourses","id", "itemsContainerForCoursesId");
                    containerForCourses.appendChild(newElem);

                    addHtmlElementsMoreInformation(newElem,'afterbegin',dataCourses,j)
                    addNewEventListenerForButtonMoreInformation(newElem,dataCourses,j,amountCourses,'AllCourse')                         
                }
                break;
            }
            if(dataCourses[i]['courseGroup']['name'].toLowerCase().split(' ').join('') == valueSelect.toLowerCase().split(' ').join(''))// если в списке выбрали конкретный курс
            {              
                newElem = document.createElement("div");
                newElem.setAttribute("class", "itemsContainerForCourses","id", "itemsContainerForCoursesId");
                containerForCourses.appendChild(newElem);

                addHtmlElementsMoreInformation(newElem,'afterbegin',dataCourses,i)
                addNewEventListenerForButtonMoreInformation(newElem,dataCourses,i,amountCourses,'AllCourse')                                                                                                                                              
            }              
        }
    }
    if(typeSelect ='All types')
    {    
        for(let i = 0; i < amountCourses.length;i++)
        {       
            if(valueSelect == 'All types')
            {           
                for(let j = 0; j < amountCourses.length;j++)
                {                                
                    newElem = document.createElement("div");
                    newElem.setAttribute("class", "itemsContainerForCourses","id", "itemsContainerForCoursesId");
                    containerForCourses.appendChild(newElem);

                    addHtmlElementsMoreInformation(newElem,'afterbegin',dataCourses,j)
                    addNewEventListenerForButtonMoreInformation(newElem,dataCourses,j,amountCourses,'AllCourse')                                         
                }
                break;

                }                         
                if(dataCourses[i]['courseType']['name'] == valueSelect)
                {                
                    newElem = document.createElement("div");
                    newElem.setAttribute("class", "itemsContainerForCourses","id", "itemsContainerForCoursesId");
                    containerForCourses.appendChild(newElem);

                    addHtmlElementsMoreInformation(newElem,'afterbegin',dataCourses,i)
                    addNewEventListenerForButtonMoreInformation(newElem,dataCourses,i,amountCourses,'AllCourse')                                                                                                          
                }                   
        }
    }
}
//Function which i use in addDataToPageAFterUseFilters
function addHtmlElementsMoreInformation(newElem,placeInsert,dataCourses,positionToArray)
{
    newElem.insertAdjacentHTML(placeInsert, `           
    <div class="divNameCourse" id="divNameCourseId">
        <p class="pNameCourse" id="pNameCourseId">${dataCourses[positionToArray]['name']}</p>
        <br />
        <button type="button" class="btn button1"> ${dataCourses[positionToArray]['courseGroup']['name'] } </button>
        <button type="button" class="btn button2"> ${dataCourses[positionToArray]['courseType']['name'] } </button>
    </div>

    <div class="divCourseDescription">
        <br />
        <br />
        ${dataCourses[positionToArray]['description']} 
    </div>
       
    <div class="divInformationCourse">
        <button type="button" class="aInformationCourse  btn" value="${dataCourses[positionToArray]['name']} /courseData ${dataCourses[positionToArray]['description']}  //courseData ${dataCourses[positionToArray]['trainers']} " id="buttonMoreInformation">
            More information
        </button>
     </div>
                                              
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
}
function addNewEventListenerForButtonMoreInformation(newElem,dataCourses,positionToArray,amountCourses,typePage)
{  
    newElem.addEventListener('click', function(e) {
        var courseName =  e.target.value.split('/courseData')[0];
        var referenceOnPage = null;
        var styleForElemTrainers = null;

        if(typePage == "ShowActionInCourseList")
        {
            document.querySelectorAll('.divForHeading').forEach(e => e.remove());
            document.querySelectorAll('.divPanelFilters').forEach(e => e.remove());
            document.querySelectorAll('.divContainerString').forEach(e => e.remove());
            document.querySelectorAll('.divLine').forEach(e => e.remove());
            document.querySelectorAll('.divContainerForInformationCourse').forEach(e => e.remove());
            referenceOnPage = "http://localhost:61558/CourseList/ShowActionInCourseList";
            styleForElemTrainers = "containerAllTrainersInMoreInforamtionAfterUseDeleteCourse"                       
        }
        if(typePage == "AllCourse")
        {
            document.querySelectorAll('.divForHeading').forEach(e => e.remove());
            document.querySelectorAll('.divPanelFilters').forEach(e => e.remove());
            document.querySelectorAll('.itemsSelectTypesPanelFilters').forEach(e => e.remove())    
            document.querySelectorAll('.itemsContainerForCourses').forEach(e => e.remove());
            referenceOnPage = "http://localhost:61558/Course/ShowAllCourses";
            styleForElemTrainers = "containerAllTrainersInMoreInforamtion";       
        }
                                                                                          
        containerForCourses = document.querySelector("div.containerForCourses");       
        newElem = document.createElement("div");
        newElem.setAttribute("class", "itemsContainerForCourses","id", "itemsContainerForCoursesId");
        containerForCourses.appendChild(newElem); 
 
        newElem.insertAdjacentHTML('afterbegin', `           
            <div class="divNameCourse" id="divNameCourseId">
                <p class="pNameCourse" id="pNameCourseId">${dataCourses[positionToArray]['name']}</p>
                <br />
                <button type="button" class="btn button1"> ${dataCourses[positionToArray]['courseGroup']['name']} </button>
                <button type="button" class="btn button2"> ${dataCourses[positionToArray]['courseType']['name'] } </button>
            </div>
    
            <div class="divCourseDescription">
                <br />
                <br />
                ${dataCourses[positionToArray]['description']} 
            </div>

            <div class="divInformationCourse">                         
            <div class="${styleForElemTrainers}" id="containerAllTrainersInMoreInforamtionId">
                <div class="itemsContainerAllTrainersInMoreInforamtion"> Trainers: </div>                       
            </div>                                                      
            </div>
            <br /> <br />        
            <a class="aBackToListActionInCourseList" href="${referenceOnPage}"> Back to list</a> 
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
                        <div class="itemsContainerAllTrainersInMoreInforamtion"> <button type="button" class="btn btn333 btn-primary" data-toggle="modal" data-target="#myModal" value="${dataCourses[i]['trainers'][j]['trainer']['description']} / ${dataCourses[i]['trainers'][j]['trainer']['user']['fullName']} ///photoTrainer///p ${dataCourses[i]['trainers'][j]['trainer']['user']['photo']} "> ${dataCourses[i]['trainers'][j]['trainer']['user']['fullName']}  </button>   </div>     
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
    });

}
///
/// Functions for ShowActionInCourseList page
function addDataToPageShowActionInCourseList(arrayTrainersCourse,newElem,mainElem,positionIndDataCourse,amountCourses)
{
    arrayTrainersCourse = [];
    allFunctions.getArrayTrainersGroup(dataCourses,amountCourses,dataCourses[positionIndDataCourse]['name'],arrayTrainersCourse);
    var stringWithDivTrainers = "";
    for(var n = 0; n <arrayTrainersCourse.length; n++)
    {
        stringWithDivTrainers += `<div class="divStringTrainers"> ${arrayTrainersCourse[n]} </div>`
    }
    newElem = document.createElement("divContainerForInformationCourse");
    newElem.setAttribute("class", "divContainerForInformationCourse");
    mainElem.appendChild(newElem);
    newElem.insertAdjacentHTML('afterbegin', `
        <div class="firstItemDivContainerForInformationCourse">
            <p class="pString">  ${dataCourses[positionIndDataCourse]['name']} </p>
        </div>
        <div class="itemsDivContainerForInformationCourse">
            <p class="pString"> ${dataCourses[positionIndDataCourse]['courseType']['name']} </p>
        </div>
        <div class="itemsDivContainerForInformationCourse">
            <p class="pString"> ${dataCourses[positionIndDataCourse]['courseGroup']['name']} </p>
        </div>
        <div class="itemsDivContainerForInformationCourse">
            ${stringWithDivTrainers}                          
        </div>
        <div class="lastItemDivContainerForInformationCourse">
            <div>
                <button type="button" class="ButtonMoreInformationCourse" value="${dataCourses[positionIndDataCourse]['name']}/courseData ${dataCourses[positionIndDataCourse]['description']} //courseData ${dataCourses[positionIndDataCourse]['trainers']}" id="buttonMoreInformation${positionIndDataCourse}">
                    More information course
                </button>
                <button type="button" class="ButtonMoreInformationCourse  btn" value="${dataCourses[positionIndDataCourse]['name']} /courseData  ${dataCourses[positionIndDataCourse]['trainers']}" id="ButtonEditCourseTrainerId${positionIndDataCourse}" >
                    Edit course trainers
                </button>
                <a class="aBackToListActionInCourseList" href="http://localhost:61558/courseList/UpdateCourse">
                    Update course
                </a>
                <button type="button" class="ButtonDeleteCourse" value="${dataCourses[positionIndDataCourse]['name']}" id="deleteCourseButtonId${positionIndDataCourse}">
                    Delete course
                </button>
            </div>
        </div>
    `);                   
    newElem.insertAdjacentHTML('afterEnd', `
        <div class="divContainerForInformationCourse">
            <div class="itemforDivContainerForInformationCourseCourseDescription">
                <div class="div1">
                    <p class="pStringCourseDescription"> ${dataCourses[positionIndDataCourse]['description']}</p>
                </div>
            </div>
        </div>                          
    `)  
}
function addHtmlElementsEditCourseTrainer(buttonAddTrainers, buttonDeleteTrainer, mainElem,newElem,dataCourses,amountCourses,arrayAllFullNameTrainers,arrayObjectTrainersCourse,stringWithElemForSelectAddTrainers,stringWithElemForEditTrainers,courseForUpdateTrainers)
{    
    mainElem = document.querySelector(".containerForCourses");
    newElem = document.createElement("div");
    newElem.setAttribute("class", "divWithData");
    mainElem.appendChild(newElem);
    newElem.insertAdjacentHTML('afterbegin', `
        <div class="divForHeading">
            <p class="h2Course">
                Update Trainers name of course ${courseName}
            </p>
        </div>      
    `);

    allFunctions.getArrayAllFullNameTrainers(dataCourses,amountCourses,arrayAllFullNameTrainers);
    arrayAllFullNameTrainers = allFunctions.getUniqueTrainers(arrayAllFullNameTrainers);
     
    for(var n = 0; n <arrayAllFullNameTrainers.length; n++)
    {
        stringWithElemForSelectAddTrainers += `<option> ${arrayAllFullNameTrainers[n]} </option> `;                   
    }
    
    stringWithElemForEditTrainers = '';
    arrayObjectTrainersCourse = []; 
    allFunctions.getArrayObjectTrainersGroup(dataCourses,amountCourses,courseForUpdateTrainers,arrayObjectTrainersCourse);

    for(var n = 0; n <arrayObjectTrainersCourse.length; n++)
    {
       stringWithElemForEditTrainers += `  <div class="divContainerForEditTrainers">
                    <div class="firstItemForEditTrainers">
                        <p class="pString"> ${arrayObjectTrainersCourse[n]['trainer']['user']['fullName']} </p>
                    </div>
                    <div class="itemContainerForEditTrainers">
                        <p class="pString">  ${arrayObjectTrainersCourse[n]['trainer']['visualOrder']} </p>
                    </div>
                    <div class="lastContainerForEditTrainers">
                        <button type="button" class="ButtonDeleteCourse" value="${arrayObjectTrainersCourse[n]['trainer']['user']['fullName']} /courseData ${arrayObjectTrainersCourse[n]['trainer']['visualOrder']} //courseData ${courseForUpdateTrainers}" id="deleteCourseEditTrainersButtonId">
                            Delete course
                        </button>
                    </div>
                </div>
                <div class="divLineUpdateTrainers">
                </div>                
        `;                  
    }

    newElem = document.createElement("div");
    newElem.setAttribute("class", "containerForUpdateTrainersCourse");
    mainElem.appendChild(newElem);
    newElem.insertAdjacentHTML('afterbegin', `
         <div class="itemSelectAddTrainersContainerForUpdateTrainersCourse">
        <div class="divAddTrainer">
            <div class="divString">
                <p class="pStringForDiv">
                    Add Trainer
                </p>
            </div>
        </div>
        <div class="divMainLineUpdateTrainers">
        </div>
        <div class="divSelectTrainers">             
            <select class="SelectTrainers" id="inlineFormCustomSelectPref">
                ${stringWithElemForSelectAddTrainers}
            </select>
            <button type="submit" class="btn btn-primary my-1" id="buttonAddId"> Add </button>        
        </div>
        <div class="divForBacToListUpdateTrainers">
            <div class="divForABackTolist">
                <a class="aBackToListUpdateTrainers" href="http://localhost:61558/courseList/ShowActionInCourseList"> Back to list </a>
            </div>  
        </div>                                               
    </div>             
    <div class="itmesEditTrainersContainerForUpdateTrainersCourse">
        <div class="divStringForDivAddTrainer">
            <div class="divEditTrainer">
                <div class="divString">
                    <p class="pStringForDiv">
                        Edit Trainers
                    </p>
                </div>
                <div class="divContainerStringUpdateTrainers">
                    <div class="firstItemdivContainerStringUpdateTrainers">
                        <p class="pStringMainLine"> Trainer </p>
                    </div>
                    <div class="itemdivContainerStringUpdateTrainers">
                        <p class="pStringMainLine"> Order </p>
                    </div>
                    <div class="lastItemdivContainerStringUpdateTrainers">
                        <p class="pStringMainLine"> Action </p>
                    </div>
                </div>
                <div class="divMainLineUpdateTrainers">
                </div>
                ${stringWithElemForEditTrainers}
           </div>               
        </div>
    </div>     
    `);
 
    buttonAddTrainers = document.getElementById('buttonAddId');
    buttonAddTrainers.addEventListener( 'click', e => {
        var elemSelect = document.getElementById('inlineFormCustomSelectPref');                
        var allDataForAddTrainer = `${elemSelect.value}/${courseForUpdateTrainers}`;
        $.get('/CourseList/AddTrainer', $.param({ allDataForAddTrainer: allDataForAddTrainer }, true), function() {          
            const request = new XMLHttpRequest();
            const url ="http://localhost:61558/CourseList/getDataCourses";
            request.onreadystatechange = function() 
            {
                if (request.readyState === 4) 
                {                                
                    var dataCourses = JSON.parse(request.response);
                    const amountCourses = Object.keys(dataCourses);
                    document.querySelectorAll('.containerForUpdateTrainersCourse').forEach(e => e.remove());
                    document.querySelectorAll('.divWithData').forEach(e => e.remove());               
                    addHtmlElementsEditCourseTrainer(buttonAddTrainers, buttonDeleteTrainer,mainElem,newElem,dataCourses,amountCourses,arrayAllFullNameTrainers,arrayObjectTrainersCourse,stringWithElemForSelectAddTrainers,stringWithElemForEditTrainers,courseForUpdateTrainers);                                                                                        
                }     
            }  
            request.open('GET',url);
            request.send();
        });     
    })
    
    buttonDeleteTrainer = document.querySelectorAll('.ButtonDeleteCourse');
    buttonDeleteTrainer.forEach(item => {
        item.addEventListener( 'click', e => {
            var trainerName =  e.target.value.split('/courseData')[0];
            var trainerVisualOrder = e.target.value.split('/courseData')[1];
            var corseName = e.target.value.split('//courseData')[1];
            var allDataForDeleteTrainer = `${trainerName}/${trainerVisualOrder}/${corseName}`;
            $.get('/CourseList/DeleteTrainer', $.param({ allDataForDeleteTrainer: allDataForDeleteTrainer }, true), function() {

                const request = new XMLHttpRequest();
                const url ="http://localhost:61558/CourseList/getDataCourses";
                request.onreadystatechange = function() 
                {
                    if (request.readyState === 4) 
                    {     
                        dataCourses = JSON.parse(request.response);
                        const amountCourses = Object.keys(dataCourses);
                        document.querySelectorAll('.containerForUpdateTrainersCourse').forEach(e => e.remove());
                        document.querySelectorAll('.divWithData').forEach(e => e.remove());
                        addHtmlElementsEditCourseTrainer(buttonAddTrainers, buttonDeleteTrainer,mainElem,newElem2,dataCourses,amountCourses,arrayAllFullNameTrainers,arrayObjectTrainersCourse,stringWithElemForSelectAddTrainers,stringWithElemForEditTrainers,courseForUpdateTrainers);                                                                                        
                    }     
                }  
                request.open('GET',url);
                request.send();               
            });            
       })
    })    
    
}
function addNewEventListenerForButtonDeleteCourse(buttonForContor,dataCourses)
{ 
    var mainElem = null;
    var newElem = null;
    var arrayTrainersCourse = [];
    var buttonId = null;

    buttonForContor.addEventListener( 'click', e => {
        var courseForDelete =  e.target.value.split('/courseData')[0];
        $.post('/CourseList/DeleteCourse', $.param({ courseName: courseForDelete }, true), function(data) {});       

        const request = new XMLHttpRequest();
        const url ="http://localhost:61558/CourseList/getDataCourses";
        request.onreadystatechange = function() 
        {
            if (request.readyState === 4) 
            {        
                dataCourses = JSON.parse(request.response);
                const amountCourses = Object.keys(dataCourses);
                document.querySelectorAll('.divContainerForInformationCourse').forEach(e => e.remove());
                mainElem = document.querySelector(".containerForCourses");
                    
                for (var i = 0; i < amountCourses.length; i++)
                {
                    if(dataCourses[i]['name'].toLowerCase().split(' ').join('') != courseForDelete.toLowerCase().split(' ').join(''))
                    {
                        arrayTrainersCourse = [];
                        allFunctions.getArrayTrainersGroup(dataCourses,amountCourses,dataCourses[i]['name'],arrayTrainersCourse);
                        var stringWithDivTrainers = "";
                        for(var n = 0; n <arrayTrainersCourse.length; n++)
                        {
                            stringWithDivTrainers += `<div class="divStringTrainers"> ${arrayTrainersCourse[n]} </div>`
                        }
                        newElem = document.createElement("divContainerForInformationCourse");
                        newElem.setAttribute("class", "divContainerForInformationCourse");
                        mainElem.appendChild(newElem);
                        newElem.insertAdjacentHTML('afterbegin', `
                            <div class="firstItemDivContainerForInformationCourse">
                                <p class="pString">  ${dataCourses[i]['name']} </p>
                            </div>
                            <div class="itemsDivContainerForInformationCourse">
                                <p class="pString"> ${dataCourses[i]['courseType']['name']} </p>
                            </div>
                            <div class="itemsDivContainerForInformationCourse">
                                <p class="pString"> ${dataCourses[i]['courseGroup']['name']} </p>
                            </div>
                            <div class="itemsDivContainerForInformationCourse">
                                ${stringWithDivTrainers}                          
                            </div>
                            <div class="lastItemDivContainerForInformationCourse">
                                <div>
                                    <button type="button" class="ButtonMoreInformationCourse" value="${dataCourses[i]['name']}/courseData ${dataCourses[i]['description']} //courseData ${dataCourses[i]['trainers']}" id="buttonMoreInformation${i}">
                                        More information course
                                    </button>
                                    <button type="button" class="ButtonMoreInformationCourse  btn" value="${dataCourses[i]['name']} /courseData  ${dataCourses[i]['trainers']}" >
                                        Edit course trainers
                                    </button>
                                    <a class="aBackToListActionInCourseList" href="http://localhost:61558/courseList/UpdateCourse">
                                        Update course
                                    </a>
                                    <button type="button" class="ButtonDeleteCourse" value="${dataCourses[i]['name']}" id="deleteCourseButtonId${i}">
                                        Delete course
                                    </button>
                                </div>
                            </div>
                        `);                   
                        newElem.insertAdjacentHTML('afterEnd', `
                            <div class="divContainerForInformationCourse">
                                <div class="itemforDivContainerForInformationCourseCourseDescription">
                                    <div class="div1">
                                        <p class="pStringCourseDescription"> ${dataCourses[i]['description']}</p>
                                    </div>
                                </div>
                            </div>                          
                        `)                    
                        buttonMoreInformationId = "buttonMoreInformation" + i.toString();
                        var buttonForContor1 = document.getElementById(buttonMoreInformationId);
                        allFunctions.addNewEventListenerForButtonMoreInformation(buttonForContor1,dataCourses,i,amountCourses,"ShowActionInCourseList");
                        
                        buttonDeleteCourseId = "deleteCourseButtonId" + i.toString();
                        var buttonForContor2 = document.getElementById(buttonDeleteCourseId);
                        allFunctions.addNewEventListenerForButtonDeleteCourse(buttonForContor2,dataCourses,i);   
                    }
                }                          
            }     
        }  
        request.open('GET',url);
        request.send();   
    })
}
function addNewEventListenerForButtonEditCourseTrainers(buttonForContor,dataCourses,mainElem,newElem,arrayAllFullNameTrainers,stringWithElemForSelectAddTrainers,stringWithElemForEditTrainers)
{
    buttonForContor.addEventListener( 'click', e => {
        var courseForUpdateTrainers =  e.target.value.split('/courseData')[0];
        const request = new XMLHttpRequest();
        const url ="http://localhost:61558/CourseList/getDataCourses";
        request.onreadystatechange = function() 
        {
            if (request.readyState === 4) 
            {
                document.querySelectorAll('.divContainerForInformationCourse').forEach(e => e.remove());
                document.querySelectorAll('.divForHeading').forEach(e => e.remove());
                document.querySelectorAll('.divPanelFilters').forEach(e => e.remove());
                document.querySelectorAll('.divContainerString').forEach(e => e.remove());
                document.querySelectorAll('.divLine').forEach(e => e.remove());         
                dataCourses = JSON.parse(request.response);

                const amountCourses = Object.keys(dataCourses);
                allFunctions.getCourseName(courseForUpdateTrainers,dataCourses,amountCourses);
            
                mainElem = document.querySelector(".containerForCourses");
                newElem = document.createElement("div");
                newElem.setAttribute("class", "divWithData");
                mainElem.appendChild(newElem);
                newElem.insertAdjacentHTML('afterbegin', `
                    <div class="divForHeading">
                        <p class="h2Course">
                            Update Trainers name of course ${courseName}
                        </p>
                    </div>      
                `);
         
                allFunctions.getArrayAllFullNameTrainers(dataCourses,amountCourses,arrayAllFullNameTrainers);
                arrayAllFullNameTrainers =  allFunctions.getUniqueTrainers(arrayAllFullNameTrainers);   
                for(var n = 0; n <arrayAllFullNameTrainers.length; n++)
                {
                    stringWithElemForSelectAddTrainers += `<option> ${arrayAllFullNameTrainers[n]} </option> `;                   
                }

                allFunctions.getArrayObjectTrainersGroup(dataCourses,amountCourses,courseForUpdateTrainers,arrayObjectTrainersCourse);
                for(var n = 0; n <arrayObjectTrainersCourse.length; n++)
                {
                   stringWithElemForEditTrainers += `  <div class="divContainerForEditTrainers">
                                <div class="firstItemForEditTrainers">
                                    <p class="pString"> ${arrayObjectTrainersCourse[n]['trainer']['user']['fullName']} </p>
                                </div>
                                <div class="itemContainerForEditTrainers">
                                    <p class="pString">  ${arrayObjectTrainersCourse[n]['trainer']['visualOrder']} </p>
                                </div>
                                <div class="lastContainerForEditTrainers">
                                    <button type="button" class="ButtonDeleteCourse" value="${arrayObjectTrainersCourse[n]['trainer']['user']['fullName']} /courseData ${arrayObjectTrainersCourse[n]['trainer']['visualOrder']} //courseData ${courseForUpdateTrainers}" id="deleteCourseEditTrainersButtonId">
                                        Delete course
                                    </button>
                                </div>
                            </div>
                            <div class="divLineUpdateTrainers">
                            </div>                
                    `;                  
                }

                newElem = document.createElement("div");
                newElem.setAttribute("class", "containerForUpdateTrainersCourse");
                mainElem.appendChild(newElem);
                newElem.insertAdjacentHTML('afterbegin', `
                     <div class="itemSelectAddTrainersContainerForUpdateTrainersCourse">
                    <div class="divAddTrainer">
                        <div class="divString">
                            <p class="pStringForDiv">
                                Add Trainer
                            </p>
                        </div>
                    </div>
                    <div class="divMainLineUpdateTrainers">
                    </div>
                    <div class="divSelectTrainers"> 
                        <select class="SelectTrainers" id="inlineFormCustomSelectPref">
                            ${stringWithElemForSelectAddTrainers}
                        </select>
                        <button type="submit" class="btn btn-primary my-1" id="buttonAddId"> Add </button>
                    </div>
                    <div class="divForBacToListUpdateTrainers">
                        <div class="divForABackTolist">
                            <a class="aBackToListUpdateTrainers" href="http://localhost:61558/courseList/ShowActionInCourseList"> Back to list </a>
                        </div>  
                    </div>                                               
                </div>             
                <div class="itmesEditTrainersContainerForUpdateTrainersCourse">
                    <div class="divStringForDivAddTrainer">
                        <div class="divEditTrainer">
                            <div class="divString">
                                <p class="pStringForDiv">
                                    Edit Trainers
                                </p>
                            </div>
                            <div class="divContainerStringUpdateTrainers">
                                <div class="firstItemdivContainerStringUpdateTrainers">
                                    <p class="pStringMainLine"> Trainer </p>
                                </div>
                                <div class="itemdivContainerStringUpdateTrainers">
                                    <p class="pStringMainLine"> Order </p>
                                </div>
                                <div class="lastItemdivContainerStringUpdateTrainers">
                                    <p class="pStringMainLine"> Action </p>
                                </div>
                            </div>
                            <div class="divMainLineUpdateTrainers">
                            </div>
                            ${stringWithElemForEditTrainers}
                       </div>               
                    </div>
                </div>     
                `);

                newElem = document.getElementById('buttonAddId');
                newElem.addEventListener( 'click', e => {
                    var elemSelect = document.getElementById('inlineFormCustomSelectPref');                
                    var allDataForAddTrainer = `${elemSelect.value}/${courseForUpdateTrainers}`;
                    $.get('/CourseList/AddTrainer', $.param({ allDataForAddTrainer: allDataForAddTrainer }, true), function() {
                        const request = new XMLHttpRequest();
                        const url ="http://localhost:61558/CourseList/getDataCourses";
                        request.onreadystatechange = function() 
                        {
                            if (request.readyState === 4) 
                            {                                
                                var dataCourses = JSON.parse(request.response);
                                const amountCourses = Object.keys(dataCourses);
                                document.querySelectorAll('.containerForUpdateTrainersCourse').forEach(e => e.remove());
                                document.querySelectorAll('.divWithData').forEach(e => e.remove());
                                var buttonDeleteTrainer = null;
                                var buttonAddTrainers = null;
                                var arrayAllFullNameTrainers = [];
                                var arrayObjectTrainersCourse = [];
                                var stringWithElemForSelectAddTrainers = "";
                                var stringWithElemForEditTrainers = "";                   
                                addHtmlElementsEditCourseTrainer(buttonAddTrainers, buttonDeleteTrainer,mainElem,newElem,dataCourses,amountCourses,arrayAllFullNameTrainers,arrayObjectTrainersCourse,stringWithElemForSelectAddTrainers,stringWithElemForEditTrainers,courseForUpdateTrainers);                                                                                        
                            }     
                        }  
                        request.open('GET',url);
                        request.send();
                    });                                                                                                         
                })

                allButtonsDeleteTrainers = document.querySelectorAll('.ButtonDeleteCourse');
                allButtonsDeleteTrainers.forEach(item => {
                    item.addEventListener( 'click', e => {
                        var trainerName =  e.target.value.split('/courseData')[0];
                        var trainerVisualOrder = e.target.value.split('/courseData')[1];
                        var corseName = e.target.value.split('//courseData')[1];
                        var allDataForDeleteTrainer = `${trainerName}/${trainerVisualOrder}/${corseName}`;
                        $.get('/CourseList/DeleteTrainer', $.param({ allDataForDeleteTrainer: allDataForDeleteTrainer }, true), function() {
                            const request = new XMLHttpRequest();
                            const url ="http://localhost:61558/CourseList/getDataCourses";
                            request.onreadystatechange = function() 
                            {
                                if (request.readyState === 4) 
                                {     
                                    dataCourses = JSON.parse(request.response);
                                    const amountCourses = Object.keys(dataCourses);          
                                    document.querySelectorAll('.containerForUpdateTrainersCourse').forEach(e => e.remove());
                                    document.querySelectorAll('.divWithData').forEach(e => e.remove());
                                    var buttonDeleteTrainer = null;
                                    var buttonAddTrainers = null;
                                    var arrayAllFullNameTrainers = [];
                                    var arrayObjectTrainersCourse = [];
                                    var stringWithElemForSelectAddTrainers = "";
                                    var stringWithElemForEditTrainers = "";      
                                    addHtmlElementsEditCourseTrainer(buttonAddTrainers, buttonDeleteTrainer,mainElem,newElem2,dataCourses,amountCourses,arrayAllFullNameTrainers,arrayObjectTrainersCourse,stringWithElemForSelectAddTrainers,stringWithElemForEditTrainers,courseForUpdateTrainers);                                                                                        
                                }     
                            }  
                            request.open('GET',url);
                            request.send();               
                        });                                                                                 
                    })
                })
            }     
        }  
        request.open('GET',url);
        request.send();                            
    })  
}
///
///Functions for Trainer list page
function addHtmlElementsEditTrainerAndAddEventForButtonUpdate (dataTrainerGroup,trainerForEdit,mainElem,newElem,stringWithElemForEditTrainer,buttonUpdateTrainer)
{
    document.querySelectorAll('.divWithData2').forEach(e => e.remove());              
    document.querySelectorAll('.containerForTrainerList').forEach(e => e.remove());
    document.querySelectorAll('.divContainerStringShowTrainerlist').forEach(e => e.remove());
    document.querySelectorAll('.divLine').forEach(e => e.remove());
    document.querySelectorAll('.divContainerForTrainerInformation').forEach(e => e.remove());


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
                                <input for="Order" class="customform-control" id="inputOrderId" value='0' />
                                <span class="spanForUpdateTrainer" style="color:red"; id="spanOrderId">  </span>
                            </div>
                            <div class="itemsUpdateTrainer">
                                <label for="textAreaId" class="labelUpdateTrainer"> Description </label>
                                <br />
                                <textarea  class="customform-control" maxlength="4000" id="textAreaId"></textarea>
                                <span class="spanForUpdateTrainer" style="color:red"; id="spanDescriptionId">  </span>                                                    
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
function addHtmlElementsDeleteTrainerAndAddEventListenerButtonEditTrainerButtonDeleteTrainer(dataTrainers,dataTrainerGroup,amountTrainers,mainElem,newElem,buttonEditTrainerId,buttonForContor1,buttonDeleteTrainer,buttonForContor2)
{
    document.querySelectorAll('.divContainerForTrainerInformation').forEach(e => e.remove());   
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
///
/// Secondary functions
function getCourseName(coursename,dataCourses,amountCourses)
{
  for(let i = 0; i < amountCourses.length;i++)
  {
      if(dataCourses[i]['name'].toLowerCase().split(' ').join('') == coursename.toLowerCase().split(' ').join(''))
      {
          courseName = dataCourses[i]['name'];
      }           
  }
}
function getCourseGroup(valueSelectCourseName,dataCourses,amountCourses)
{
  for(let i = 0; i < amountCourses.length;i++)
  {
      if(dataCourses[i]['name'].toLowerCase().split(' ').join('') == valueSelectCourseName.toLowerCase().split(' ').join(''))
      {
          courseGroupName = dataCourses[i]['courseGroup']['name'];
      }
            
  }
}
function getCourseType(valueSelectCourseName,dataCourses,amountCourses)
{
  for(let i = 0; i < amountCourses.length;i++)
  {
      if(dataCourses[i]['name'].toLowerCase().split(' ').join('') == valueSelectCourseName.toLowerCase().split(' ').join(''))
      {
        courseTypeName = dataCourses[i]['courseType']['name'];
      }          
  }
}
function getCourseVisualOrder(valueSelectCourseName,dataCourses,amountCourses)
{
  for(let i = 0; i < amountCourses.length;i++)
  {
      if(dataCourses[i]['name'].toLowerCase().split(' ').join('') == valueSelectCourseName.toLowerCase().split(' ').join(''))
      {
        courseVisualOrder = dataCourses[i]['visualOrder'];
      }          
  }
}
function getCourseDescription(valueSelectCourseName,dataCourses,amountCourses)
{
  for(let i = 0; i < amountCourses.length;i++)
  {
      if(dataCourses[i]['name'].toLowerCase().split(' ').join('') == valueSelectCourseName.toLowerCase().split(' ').join(''))
      {
        courseDescription = dataCourses[i]['description'];
      }          
  }
}
function getArrayTrainersGroup (dataCourses,amountCourses,courseName,arrayTrainersCourse)
{
    for(let i = 0; i < amountCourses.length;i++)
    {      
        if(dataCourses[i]['name'].toLowerCase().split(' ').join('') == courseName.toLowerCase().split(' ').join(''))
        {         
            for(let z = 0; z < dataCourses[i]['trainers'].length;z++)
            {             
              arrayTrainersCourse[z] = dataCourses[i]['trainers'][z]['trainer']['user']['fullName'];    
            }            
        }      
    }
}
function getArrayObjectTrainersGroup (dataCourses,amountCourses,courseName,arrayObjectTrainersCourse)
{  
    for(let i = 0; i < amountCourses.length;i++)
    {             
        if(dataCourses[i]['name'].toLowerCase().split(' ').join('') == courseName.toLowerCase().split(' ').join(''))
        {    
            for(let z = 0; z < dataCourses[i]['trainers'].length;z++)
            {        
                arrayObjectTrainersCourse[z] = dataCourses[i]['trainers'][z];    
            }            
        }         
    }
}
function getArrayAllFullNameTrainers (dataCourses,amountCourses,arrayAllFullNameTrainers)
{
    var positionInArray = 0;
    for(let i = 0; i < amountCourses.length;i++)
    {                 
        for(let z = 0; z < dataCourses[i]['trainers'].length;z++)
        {                 
            arrayAllFullNameTrainers[positionInArray] = dataCourses[i]['trainers'][z]['trainer']['user']['fullName'];
            positionInArray +=1;    
        }                       
    }
}
function getUniqueTrainers(arr) {
    let result = [];
  
    for (let str of arr) {
      if (!result.includes(str)) {
        result.push(str);
      }
    }
    return result;
}

const allFunctions = {
    addDataToPageAFterUseFilters:addDataToPageAFterUseFilters,
    addDataToPageShowActionInCourseList:addDataToPageShowActionInCourseList,
    addHtmlElementsMoreInformation:addHtmlElementsMoreInformation,
    addHtmlElementsEditCourseTrainer:addHtmlElementsEditCourseTrainer,
    addHtmlElementsEditTrainerAndAddEventForButtonUpdate:addHtmlElementsEditTrainerAndAddEventForButtonUpdate,
    addHtmlElementsDeleteTrainerAndAddEventListenerButtonEditTrainerButtonDeleteTrainer:addHtmlElementsDeleteTrainerAndAddEventListenerButtonEditTrainerButtonDeleteTrainer,
    addNewEventListenerForButtonMoreInformation:addNewEventListenerForButtonMoreInformation,
    addNewEventListenerForButtonEditCourseTrainers:addNewEventListenerForButtonEditCourseTrainers,
    getCourseName : getCourseName,
    getCourseGroup:getCourseGroup, 
    getCourseType:getCourseType,
    getCourseVisualOrder:getCourseVisualOrder,
    getCourseDescription:getCourseDescription,
    getArrayTrainersGroup:getArrayTrainersGroup,
    getArrayObjectTrainersGroup:getArrayObjectTrainersGroup,
    getArrayAllFullNameTrainers:getArrayAllFullNameTrainers,
    getUniqueTrainers:getUniqueTrainers,
    addNewEventListenerForButtonDeleteCourse:addNewEventListenerForButtonDeleteCourse  
};


