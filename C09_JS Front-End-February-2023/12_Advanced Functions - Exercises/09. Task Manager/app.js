function solve() {
    document.getElementById('add').addEventListener('click', addTask);
    const openSectionElement = document.querySelector('.wrapper section:nth-child(2) div:nth-child(2)');
    const inProgressSectionElement = document.querySelector('.wrapper section:nth-child(3) div:nth-child(2)'); 
    const completeSectionElement = document.querySelector('.wrapper section:nth-child(4) div:nth-child(2)'); 

    function addTask(e){
        const inputs = Array.from(e.target.parentElement.querySelectorAll('input, textarea'));

        if(inputs.some(x => x.value === '')){
            return;
        }

        createTask(inputs);
        inputs.forEach(x => x.value = '');
    }

    function createTask(inputs){
        const articleElement = document.createElement('article');
        const divElement = document.createElement('div');
        const startBtn = document.createElement('button');
        const deleteBtn = document.createElement('button');

        articleElement.innerHTML = 
        `<h3>${inputs[0].value}</h3>
        <p>Description: ${inputs[1].value}</p>
        <p>Due Date: ${inputs[2].value}</p>`;

        divElement.classList.add('flex');

        //Start btn
        startBtn.classList.add('green');
        startBtn.textContent = 'Start';
        startBtn.addEventListener('click', startTask);

        //Delete btn
        deleteBtn.classList.add('red');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', deleteTask);

        divElement.appendChild(startBtn);
        divElement.appendChild(deleteBtn);

        articleElement.appendChild(divElement);
        openSectionElement.appendChild(articleElement);
    }

    function startTask(e){
       const articleElement = e.target.parentElement.parentElement;
       const btnsDiv = articleElement.querySelector('.flex');

       btnsDiv.querySelector('button:nth-child(1)').remove();

       const finishBtn = document.createElement('button');
       finishBtn.classList.add('orange');
       finishBtn.textContent = 'Finish';
       finishBtn.addEventListener('click', finishTask);

       btnsDiv.appendChild(finishBtn);
       inProgressSectionElement.appendChild(articleElement);
    }

    function deleteTask(e){
        e.target.parentElement.parentElement.remove();
    }

    function finishTask(e){
        const article = e.target.parentElement.parentElement;
        article.getElementsByClassName('flex')[0].remove();

        completeSectionElement.appendChild(article);
    }
}