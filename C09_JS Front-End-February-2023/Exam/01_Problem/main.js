function solve(input) {
  const n = Number(input.shift());
  const initialData = input.splice(0, n);
  const board = [];

  for (let index = 0; index < initialData.length; index++) {
    const tokens = initialData[index].split(':');
    if(!board.some(x => x.assignee === tokens[0])){
      const obj = {
        assignee: tokens[0],
        tasks: [{
          taskId: tokens[1],
          title: tokens[2],
          status: tokens[3],
          estimatedPoints: Number(tokens[4])
        }]
      }
      board.push(obj);
      continue;
    }

    const assigneeObj = board.find(x => x.assignee === tokens[0]);
    assigneeObj.tasks.push({
      taskId: tokens[1],
      title: tokens[2],
      status: tokens[3],
      estimatedPoints: Number(tokens[4])
    });
  }

  for (let index = 0; index < input.length; index++) {
    const tokens = input[index].split(':');
    const command = tokens[0];

    if(command === 'Add New'){
      const assignee = tokens[1];
      const taskId = tokens[2];
      const title = tokens[3];
      const status = tokens[4];
      const estimatedPoints = Number(tokens[5]);

      addAssignee(assignee, taskId, title, status, estimatedPoints);
    }
    else if(command === 'Change Status'){
      const assignee = tokens[1];
      const taskId = tokens[2];
      const newStatus = tokens[3];

      changeStatus(assignee, taskId, newStatus);
    } 
    else if(command === 'Remove Task'){
      const assignee = tokens[1];
      const index = Number(tokens[2]);
      removeTask(assignee, index);
    }
  }
  
  function addAssignee(assignee, taskId, title, status, estimatedPoints){
    if(!board.some(x => x.assignee === assignee)){
      console.log(`Assignee ${assignee} does not exist on the board!`);
      return;
    }

    const obj = board.find(x => x.assignee === assignee);
    obj.tasks.push({taskId, title, status, estimatedPoints});
  }

  function changeStatus(assignee, taskId, newStatus){
    if(!board.some(x => x.assignee === assignee)){
      console.log(`Assignee ${assignee} does not exist on the board!`);
      return;
    }

    const assigneeObj = board.find(x => x.assignee === assignee);
    if(!assigneeObj.tasks.some(t => t.taskId === taskId)){
      console.log(`Task with ID ${taskId} does not exist for ${assignee}!`);
      return;
    }

    const task = assigneeObj.tasks.find(x => x.taskId === taskId);
    task.status = newStatus;
  }

  function removeTask(assignee, index){
    if(!board.some(x => x.assignee === assignee)){
      console.log(`Assignee ${assignee} does not exist on the board!`);
      return;
    }

    const assigneeObj = board.find(x => x.assignee === assignee);
    if(index < 0 || index >= assigneeObj.tasks.length){
      console.log('Index is out of range!');
      return;
    }

    assigneeObj.tasks.splice(index, 1);
  }
  
  let toDoPoints = 0;
  let inProgressPoints = 0;
  let codeReviewPoints = 0;
  let donePoints = 0;

  for (const assigneeObj of board) {
    for (const task of assigneeObj.tasks) {
      switch (task.status) {
        case 'ToDo': toDoPoints += task.estimatedPoints; break;
        case 'In Progress': inProgressPoints += task.estimatedPoints; break;
        case 'Code Review': codeReviewPoints += task.estimatedPoints; break;
        case 'Done': donePoints += task.estimatedPoints; break;
      }
    }
  }

  console.log(`ToDo: ${toDoPoints}pts`);
  console.log(`In Progress: ${inProgressPoints}pts`);
  console.log(`Code Review: ${codeReviewPoints}pts`);
  console.log(`Done Points: ${donePoints}pts`);

  if(donePoints >= (toDoPoints + inProgressPoints + codeReviewPoints)){
    console.log('Sprint was successful!');
  } else {
    console.log('Sprint was unsuccessful...');
  }
}

solve(  [
  '4',
  'Kiril:BOP-1213:Fix Typo:Done:1',
  'Peter:BOP-1214:New Products Page:In Progress:2',
  'Mariya:BOP-1215:Setup Routing:ToDo:8',
  'Georgi:BOP-1216:Add Business Card:Code Review:3',
  'Add New:Sam:BOP-1237:Testing Home Page:Done:3',
  'Change Status:Georgi:BOP-1216:Done',
  'Change Status:Will:BOP-1212:In Progress',
  'Remove Task:Georgi:3',
  'Change Status:Mariya:BOP-1215:Done',
]
);
