window.addEventListener('load', solve);

function solve() {
    const createTaskBtn = document.getElementById('create-task-btn');
    const deleteTaskBtn = document.getElementById('delete-task-btn');

    const tasksSections = document.getElementById('tasks-section');
    const taskIdElement = document.getElementById('task-id');
    const totalPointsElement = document.getElementById('total-sprint-points');
    const titleElement = document.getElementById('title');
    const descriptionElement = document.getElementById('description');
    const selectElement = document.getElementById('label');
    const pointsElement = document.getElementById('points');
    const assigneeElement = document.getElementById('assignee');

    const inputs = [titleElement, selectElement, descriptionElement, pointsElement, assigneeElement];
    let idCounter = 1;
    let totalPoints = 0;

    createTaskBtn.addEventListener('click', createTask);
    deleteTaskBtn.addEventListener('click', deleteTask);

    function createTask(){
        if(inputs.some(x => x.value === '')){
            return;
        }

        const selectValue = selectElement.options[selectElement.selectedIndex].value
        let labelClass, labelIcon;

        switch (selectValue) {
            case 'Feature': labelClass = 'feature'; labelIcon = '&#8865'; break;
            case 'Low Priority Bug': labelClass = 'low-priority'; labelIcon ='&#9737'; break;
            case 'High Priority Bug': labelClass = 'high-priority'; labelIcon = '&#9888'; break;
        }

        const id = `task-${idCounter}`;

        const taskArticle = document.createElement('article');
        const labelDiv = document.createElement('div');
        const h3 = document.createElement('h3');
        const descP = document.createElement('p');
        const pointsDiv = document.createElement('div');
        const assigneeDiv = document.createElement('div');
        const btnsDiv = document.createElement('div');
        const deleteBtn = document.createElement('button');

        labelDiv.innerHTML = `${selectValue} ${labelIcon}`;
        h3.textContent = titleElement.value;
        descP.textContent = descriptionElement.value;
        pointsDiv.textContent = `Estimated at ${pointsElement.value} pts`;
        assigneeDiv.textContent = `Assigned to: ${assigneeElement.value}`;
        deleteBtn.textContent = 'Delete';

        deleteBtn.addEventListener('click', loadInformationToForm);

        taskArticle.id = id;
        taskArticle.classList.add('task-card');

        labelDiv.classList.add('task-card-label');
        labelDiv.classList.add(labelClass);

        h3.classList.add('task-card-title');
        descP.classList.add('task-card-description');
        pointsDiv.classList.add('task-card-points');
        assigneeDiv.classList.add('task-card-assignee');
        btnsDiv.classList.add('task-card-actions');

        btnsDiv.appendChild(deleteBtn);
        taskArticle.appendChild(labelDiv);
        taskArticle.appendChild(h3);
        taskArticle.appendChild(descP);
        taskArticle.appendChild(pointsDiv);
        taskArticle.appendChild(assigneeDiv);
        taskArticle.appendChild(btnsDiv);
        tasksSections.appendChild(taskArticle);

        idCounter++;
        updatePoints(Number(pointsElement.value), 'increase');
        inputs.forEach(x => x.value = '');
    }

    function loadInformationToForm(e){
        const parent = e.target.parentNode.parentNode;

        const title = parent.getElementsByClassName('task-card-title')[0].textContent;
        const description = parent.getElementsByClassName('task-card-description')[0].textContent;
        const label = parent.getElementsByClassName('task-card-label')[0].textContent.split(' ');
        const labelValue = label.slice(0, label.length - 1).join(' ');
        const points = Number(parent.getElementsByClassName('task-card-points')[0].textContent.split(' ')[2]);
        const assignee = parent.getElementsByClassName('task-card-assignee')[0].textContent.split(':')[1].trim();

        taskIdElement.value = parent.id;
        titleElement.value = title;
        descriptionElement.value = description;
        selectElement.value = labelValue;
        pointsElement.value = points;
        assigneeElement.value = assignee;

        inputs.forEach(x => x.disabled = true);

        createTaskBtn.disabled = true;
        deleteTaskBtn.disabled = false;
    }

    function deleteTask(){
        const taskId = taskIdElement.value;
        const task = document.getElementById(taskId);
        task.remove();

        updatePoints(Number(pointsElement.value), '');
        
        inputs.forEach(x => x.value = '');
        inputs.forEach(x => x.disabled = false);

        createTaskBtn.disabled = false;
        deleteTaskBtn.disabled = true;
    }

    function updatePoints(points, operation){
        if(operation === 'increase'){
            totalPoints += points;
        } else {
            totalPoints -= points;
        }

        totalPointsElement.textContent = `Total Points ${totalPoints}pts`;
    }
}