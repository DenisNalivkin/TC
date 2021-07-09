var inputNameNewCourse = document.getElementById("InputNameNewCourseId");

inputNameNewCourse.addEventListener('change', e => { 
    var nameNewCourse = e.target.value; 
    
    const request = new XMLHttpRequest();
    const url ="http://localhost:61558/CourseList/getDataCourses";
    request.onreadystatechange = function() 
    {
        if (request.readyState === 4) 
        {      
            dataCourses = JSON.parse(request.response);
            const amountCourses = Object.keys(dataCourses);
            for(let i = 0; i < amountCourses.length;i++)
            {
                if(dataCourses[i]['name'].toLowerCase().split(' ').join('') == nameNewCourse.toLowerCase().split(' ').join(''))
                {
                    alert("Course нашли!")      
                    document.getElementById('InputCheckBoxId').value = false;
                    document.getElementById('InputCheckBoxId').checked = false;
                    break;
                }
                else
                {
                    document.getElementById('InputCheckBoxId').value = true;
                    document.getElementById('InputCheckBoxId').checked = true;
                    break;
                }                         
            }          
        }
    }  
    request.open('GET',url);
    request.send();    
})
 

