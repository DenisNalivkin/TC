var allButtons = document.querySelectorAll('.btn');
var img = document.getElementById('imgTrainerLocation')


allButtons.forEach(item => {
    item.addEventListener('click', e => { 
        var trainerFullName =  e.target.value.split('/')[1];
        var trainerDescription = e.target.value.split('/')[0];
        var photoTrainer = e.target.value.split('///photoTrainer///p')[1];
      
     
        var h4ModalTitle =  document.getElementsByClassName('modal-title');
        h4ModalTitle[0].innerHTML =  trainerFullName;      
        img.setAttribute('src',photoTrainer);

        var divModalBody =  document.getElementsByClassName('modal-body');
        divModalBody[0].innerHTML =  trainerDescription;       
    })
  })

  
