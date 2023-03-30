function attachEvents() {
  const url = 'http://localhost:3030/jsonstore/collections/students';

  const tableBodyElement = document.querySelector('#results tbody');
  const inputsAsArr = Array.from(document.querySelectorAll('.inputs input'));

  loadData();
  document.getElementById('submit').addEventListener('click', addStudent);

  async function loadData(){
    try {
      const request = await fetch(url);
      const studentsData = Object.values(await request.json());

      console.log(studentsData);
      for (const student of studentsData) {
        tableBodyElement.innerHTML += `<tr>
        <td>${student.firstName}</td>
        <td>${student.lastName}</td>
        <td>${student.facultyNumber}</td>
        <td>${student.grade}</td>
        </tr>`;
      }

    } catch (error) {
      console.log(error);
    }
  }

  async function addStudent(){

    if(inputsAsArr.some(s => s.value === '')){
      return;
    }

    const studentObj = {
      firstName: inputsAsArr[0].value,
      lastName: inputsAsArr[1].value,
      facultyNumber: inputsAsArr[2].value,
      grade: inputsAsArr[3].value
    };

    const headers = {
      method: 'POST',
      body: JSON.stringify(studentObj)
    }

    try {
      const request = await fetch(url, headers);
      inputsAsArr.forEach(i => i.value = '');
      loadData();
    } catch (error) {
      console.log(error);
    }

  }
}

attachEvents();