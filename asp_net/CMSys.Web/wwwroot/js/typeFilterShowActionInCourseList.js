var selectTypes = document.getElementById("selectTypesId");    
var dataCourses = null;
var containerForCourses = null;
var newElem = null;
var mainElem = null;
var arrayTrainersCourse = [];
var buttonMoreInformationId = null;
var buttonDeleteCourseId = null;
var buttonEditTrainers = null;
var buttonForContor1 = null;
var buttonForContor2 = null;
var buttonForContor3 = null;
var stringWithElemForSelectAddTrainers = "";
var stringWithElemForEditTrainers = "";

selectTypes.addEventListener('change',function(){ 

    var valueSelectType = document.getElementById("selectTypesId").selectedOptions[0].value;
    document.querySelectorAll('.divContainerForInformationCourse').forEach(e => e.remove());
     
    const request = new XMLHttpRequest();
    const url ="http://localhost:61558/CourseList/getDataCourses";
    request.onreadystatechange = function() 
    {
        if (request.readyState === 4) 
        {
            dataCourses = JSON.parse(request.response);
            mainElem = document.querySelector(".containerForCourses");
            const amountCourses = Object.keys(dataCourses);
            if(valueSelectType == 'All types')
            {                    
                for (var i = 0; i < amountCourses.length; i++)
                {
                    allFunctions.addDataToPageShowActionInCourseList(arrayTrainersCourse,newElem,mainElem,i,amountCourses);                            
                    buttonMoreInformationId = "buttonMoreInformation" + i.toString();
                    buttonForContor1 = document.getElementById(buttonMoreInformationId);
                    allFunctions.addNewEventListenerForButtonMoreInformation(buttonForContor1,dataCourses,i,amountCourses,"ShowActionInCourseList");

                    buttonDeleteCourseId = "deleteCourseButtonId" + i.toString();
                    buttonForContor2 = document.getElementById(buttonDeleteCourseId);
                    allFunctions.addNewEventListenerForButtonDeleteCourse(buttonForContor2,dataCourses);

                    buttonEditTrainers = "ButtonEditCourseTrainerId" + i.toString();
                    buttonForContor3 = document.getElementById(buttonEditTrainers);
                    allFunctions.addNewEventListenerForButtonEditCourseTrainers (buttonForContor3,dataCourses,mainElem,newElem,arrayAllFullNameTrainers,stringWithElemForSelectAddTrainers,stringWithElemForEditTrainers);             
                }
            }
            else
            {
                for (var i = 0; i < amountCourses.length; i++)
                {                    
                    if(dataCourses[i]['courseType']['name'].toLowerCase().split(' ').join('') == valueSelectType.toLowerCase().split(' ').join(''))
                    {
                        allFunctions.addDataToPageShowActionInCourseList(arrayTrainersCourse,newElem,mainElem,i,amountCourses);        
                        buttonMoreInformationId = "buttonMoreInformation" + i.toString();
                        buttonForContor1 = document.getElementById(buttonMoreInformationId);
                        allFunctions.addNewEventListenerForButtonMoreInformation(buttonForContor1,dataCourses,i,amountCourses,"ShowActionInCourseList");
                        
                        buttonDeleteCourseId = "deleteCourseButtonId" + i.toString();
                        buttonForContor2 = document.getElementById(buttonDeleteCourseId);
                        allFunctions.addNewEventListenerForButtonDeleteCourse(buttonForContor2,dataCourses);

                        buttonEditTrainers = "ButtonEditCourseTrainerId" + i.toString();
                        buttonForContor3 = document.getElementById(buttonEditTrainers);
                        allFunctions.addNewEventListenerForButtonEditCourseTrainers (buttonForContor3,dataCourses,mainElem,newElem,arrayAllFullNameTrainers,stringWithElemForSelectAddTrainers,stringWithElemForEditTrainers);             
                    }                       
                }
            }
        }
    }  
    request.open('GET',url);
    request.send(); 
})




