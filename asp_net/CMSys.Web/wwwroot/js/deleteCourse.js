var allButtons = document.querySelectorAll('.ButtonDeleteCourse');
var dataCourses = null;
var mainElem = null;
var newElem = null;
var containerForCourses = null;
var arrayTrainersCourse = [];
var buttonMoreInformationId = null;
var buttonDeleteCourseId = null;
var buttonForContor1 = null;
var buttonForContor2 = null;

allButtons.forEach(item => {
    item.addEventListener( 'click', e => {       
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
                    allFunctions.addDataToPageShowActionInCourseList(arrayTrainersCourse,newElem,mainElem,i,amountCourses);                                  
                    buttonMoreInformationId = "buttonMoreInformation" + i.toString();
                    buttonForContor1 = document.getElementById(buttonMoreInformationId);
                    allFunctions.addNewEventListenerForButtonMoreInformation(buttonForContor1,dataCourses,i,amountCourses,"ShowActionInCourseList");
                    
                    buttonDeleteCourseId = "deleteCourseButtonId" + i.toString();
                    buttonForContor2 = document.getElementById(buttonDeleteCourseId);
                    allFunctions.addNewEventListenerForButtonDeleteCourse(buttonForContor2,dataCourses);
                }
            }
        }     
    }  
    request.open('GET',url);
    request.send();   
    })
})






    

