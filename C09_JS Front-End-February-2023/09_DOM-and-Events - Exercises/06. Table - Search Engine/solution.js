function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const searchField = document.getElementById('searchField');
      const tableRows = Array.from(document.querySelectorAll('.container tbody tr'));
      
      tableRows.forEach(x => x.classList.remove('select'));
      let regex = new RegExp(searchField.value);

      for (const row of tableRows) {
         for (const td of row.children) {
            if(td.innerText.match(regex) !== null){
               row.classList.add('select');
            }
         }
      }

      searchField.value = '';
   }
}