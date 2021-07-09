var selectTypes = document.getElementById("selectGroupsId");    
var dataCourses = null;
var containerForCourses = null;
var newElem = null;

selectTypes.addEventListener('change',function(){  
    var valueSelectGroup = document.getElementById("selectGroupsId").selectedOptions[0].value;
    document.querySelectorAll('.itemsContainerForCourses').forEach(e => e.remove());

    if(dataCourses == null)
    {
        const request = new XMLHttpRequest();
        const url ="http://localhost:61558/Course/getDataCourses";
        request.onreadystatechange = function() 
        {
            if (request.readyState === 4) 
            {      
                containerForCourses = document.querySelector("div.containerForCourses");
                dataCourses = JSON.parse(request.response);
                const amountCourses = Object.keys(dataCourses);
                allFunctions.addDataToPageAFterUseFilters(newElem,containerForCourses,dataCourses,amountCourses,valueSelectGroup,'All groups');
            }
        }  
        request.open('GET',url);
        request.send(); 
    }
    else
    {
        const amountCourses = Object.keys(dataCourses);
        allFunctions.addDataToPageAFterUseFilters(newElem,containerForCourses,dataCourses,amountCourses,valueSelectGroup,'All groups');
    } 
  })


