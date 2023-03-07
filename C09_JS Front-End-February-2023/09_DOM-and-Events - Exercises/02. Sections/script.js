function create(words) {

   const contentElement = document.getElementById('content');
   const divs = [];

   for (const word of words) {
      const divElement = document.createElement('div');
      const pElement = document.createElement('p');

      pElement.innerText = word;
      pElement.style.display = 'none';
      divElement.appendChild(pElement);

      divElement.addEventListener('click', function() {
         divElement.children[0].style.display = 'block';
      });

      divs.push(divElement);
   }

   divs.forEach(d => contentElement.appendChild(d));
}