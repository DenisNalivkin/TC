var allButtons = document.querySelectorAll('.ButtonEditCourseTrainer');
var buttonDeleteTrainer = null;
var buttonAddTrainers = null;
var newElem = null;
var newElem2 = null;
var mainElem = null;
var courseName = null;
var arrayAllFullNameTrainers = [];
var arrayObjectTrainersCourse = [];
var stringWithElemForSelectAddTrainers = "";
var stringWithElemForEditTrainers = "";
var dataCourses = null;


allButtons.forEach(item => {
    item.addEventListener( 'click', e => {
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
                allFunctions.addHtmlElementsEditCourseTrainer(buttonAddTrainers, buttonDeleteTrainer,mainElem,newElem,dataCourses,amountCourses,arrayAllFullNameTrainers,arrayObjectTrainersCourse,stringWithElemForSelectAddTrainers,stringWithElemForEditTrainers,courseForUpdateTrainers);                           
            }     
        }  
        request.open('GET',url);
        request.send();       
    })
})











    

