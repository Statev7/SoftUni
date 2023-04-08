// TODO:
function attachEvents() {
    const URL = 'http://localhost:3030/jsonstore/tasks/';
    const loadBtn = document.getElementById('load-board-btn');
    const createBtn = document.getElementById('create-task-btn');

    const todoSection = document.getElementById('todo-section');
    const inProgressSection = document.getElementById('in-progress-section');
    const codeReviewSection = document.getElementById('code-review-section');
    const doneSection = document.getElementById('done-section');
    const title = document.getElementById('title');
    const description = document.getElementById('description');

    loadBtn.addEventListener('click', loadTasks);
    createBtn.addEventListener('click', addTask);

    async function loadTasks(){

        todoSection.innerHTML = '';
        inProgressSection.innerHTML = '';
        codeReviewSection.innerHTML = '';
        doneSection.innerHTML = '';
        try {
            const request = await fetch(URL);
            const tasks = await request.json();

            for (const task of Object.values(tasks)) {
                const li = document.createElement('li');
                const h3 = document.createElement('h3');
                const p = document.createElement('p');
                const button = document.createElement('button');

                h3.textContent = task.title;
                p.textContent = task.description;
                button.id = task._id;

                li.classList.add('task');

                button.addEventListener('click', moveOrDeleteTask);

                li.appendChild(h3);
                li.appendChild(p);
                li.appendChild(button);

                if(task.status === 'ToDo'){
                    button.textContent = 'Move to In Progress';
                    todoSection.appendChild(li);
                } 
                else if(task.status === 'In Progress'){
                    button.textContent = 'Move to Code Review';
                    inProgressSection.appendChild(li);
                }
                else if (task.status === 'Code Review'){
                    button.textContent = 'Move to Done';
                    codeReviewSection.appendChild(li);
                }
                else if(task.status === 'Done') {
                    button.textContent = 'Close';
                    doneSection.appendChild(li);
                }
            }
        } catch (error) {
            
        }

    }

    async function addTask(){
        const object = {title: title.value, description: description.value, status: "ToDo"};
        const headers = {
            method: 'POST',
            body: JSON.stringify(object)
        };

        try {
            const request = await fetch(URL, headers);
            title.value = '';
            description.value = '';
            loadTasks();
        } catch (error) {
            
        }
    }

    function moveOrDeleteTask(e){
        if(e.target.textContent !== 'Close'){
            updateTask(e.target);
        }
        else {
            deleteTask(e.target.id);
        }
    }

    async function updateTask(button){
        const status = button.textContent;
        let newStatus;

        switch (status) {
            case 'Move to In Progress': newStatus = 'In Progress'; break;
            case 'Move to Code Review': newStatus = 'Code Review'; break;
            case 'Move to Done': newStatus = 'Done'; break;
        }
        
        const obj = {status: newStatus}
        const headers = {
            method: 'PATCH',
            body: JSON.stringify(obj),
        }

        try {
            const request = await fetch(`${URL}${button.id}`, headers);
            loadTasks();
        } catch (error) {
            
        }
    }

    async function deleteTask(id){
        const headers = {
            method: 'DELETE',
        }

        try {
            const request = await fetch(`${URL}${id}`, headers);
            loadTasks();
        } catch (error) {
            
        }
    }
}

attachEvents();