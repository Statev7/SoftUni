function solve() {
  const tableBody = document.querySelector('.table tbody');

  document.getElementsByTagName('button')[0].addEventListener('click', generateNewItem);
  document.getElementsByTagName('button')[1].addEventListener('click', generateResult);

  function generateNewItem(){
    const items = Array.from(JSON.parse(document.querySelector('#exercise > textarea').value));
    
    for (const item of items) {
      const tableRow = document.createElement('tr');

      for (const [key, value] of Object.entries(item)) {
        const tableData = document.createElement('td');

        if(key === 'img'){
          tableData.innerHTML = `<img src='${value}'/>`
        } else {
          tableData.innerText = value;
        }

        tableRow.appendChild(tableData);
      }

      const tableData = document.createElement('td');
      tableData.innerHTML = `<input type="checkbox">`
      tableRow.appendChild(tableData);

      tableBody.appendChild(tableRow);
    }
  }

  function generateResult(){
    const area = document.getElementsByTagName('textarea')[1];
    const checkedBoxs = Array.from(document.querySelectorAll('input[type="checkbox"]:checked'));
    
    const furniture = [];
    let sum = 0;
    let factor = 0;
    checkedBoxs.forEach(x => {
      const row = x.parentElement.parentElement;

      furniture.push(row.children[1].innerText);
      sum += Number(row.children[2].innerText);
      factor += Number(row.children[3].innerText);
    });

    area.innerHTML = `Bought furniture: ${furniture.join(', ')}\nTotal price: ${sum.toFixed(2)}\nAverage decoration factor: ${factor / furniture.length}`;
  }
}