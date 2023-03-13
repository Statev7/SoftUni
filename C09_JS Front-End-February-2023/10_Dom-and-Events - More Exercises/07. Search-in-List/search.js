function search() {
   const ulTownsElement = Array.from(document.querySelectorAll('#towns li'));
   const inputText = document.getElementById('searchText').value;
   const resultElement = document.getElementById('result');

   ulTownsElement.forEach(t => t.style.cssText = "text-decoration: none; font-weight: normal;");
   const matches = [];

   for (const li of ulTownsElement) {
      if(li.textContent.includes(inputText) && inputText){
         matches.push(li);
      }
   }

   matches.forEach(t => t.style.cssText = "text-decoration: underline; font-weight: bold;");

   resultElement.textContent = `${matches.length} matches found`;
}
