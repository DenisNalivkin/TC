var selectTypes = document.getElementById("selectCourseNameId");
var dataCourses = null;
var courseGroupName = null;
var courseTypeName = null;
var courseVisualOrder = null;
var courseDescription = null;

selectTypes.addEventListener('change',function(){  
    var valueSelectCourseName = document.getElementById("selectCourseNameId").selectedOptions[0].value;
    if(dataCourses == null)
    {
        const request = new XMLHttpRequest();
        const url ="http://localhost:61558/Course/getDataCourses";
        request.onreadystatechange = function() 
        {
            if (request.readyState === 4) 
            {   
                dataCourses = JSON.parse(request.response);
                const amountCourses = Object.keys(dataCourses);
                allFunctions.getCourseGroup(valueSelectCourseName,dataCourses,amountCourses);
                document.getElementById("selectCourseGroupId").value = courseGroupName;
                allFunctions.getCourseType(valueSelectCourseName,dataCourses,amountCourses);
                document.getElementById("selectCourseTypeId").value = courseTypeName;
                allFunctions.getCourseVisualOrder(valueSelectCourseName,dataCourses,amountCourses);
                document.getElementById("inputOrderId").value = courseVisualOrder;
                allFunctions.getCourseDescription(valueSelectCourseName,dataCourses,amountCourses);
                document.getElementById("textareaDescriptionId").value = courseDescription;
            }
        }  
        request.open('GET',url);
        request.send(); 
    }
    else
    {
        const amountCourses = Object.keys(dataCourses);
        allFunctions.getCourseGroup(valueSelectCourseName,dataCourses,amountCourses);
        document.getElementById("selectCourseGroupId").value = courseGroupName;
        allFunctions.getCourseType(valueSelectCourseName,dataCourses,amountCourses);
        document.getElementById("selectCourseTypeId").value = courseTypeName;
        allFunctions.getCourseVisualOrder(valueSelectCourseName,dataCourses,amountCourses);
        document.getElementById("inputOrderId").value = courseVisualOrder;
        allFunctions.getCourseDescription(valueSelectCourseName,dataCourses,amountCourses);
        document.getElementById("textareaDescriptionId").value = courseDescription;            
    } 
  })


 
  