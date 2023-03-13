function solve() {
   const shopingCardElement = document.getElementsByClassName('shopping-cart')[0];
   shopingCardElement.addEventListener('click', shoping);

   const resultElement = document.getElementsByTagName('textarea')[0];
   const products = new Set();
   let sum = 0;

   function shoping(event){
      const element = event.target;

      if(element.tagName !== 'BUTTON'){
         return;
      }

      if(element.classList.contains('add-product')){
         const parent = element.parentElement.parentElement;
         
         const name = parent.getElementsByClassName('product-title')[0].textContent;
         const price = parent.getElementsByClassName('product-line-price')[0].textContent;

         products.add(name);
         sum += Number(price);

         resultElement.textContent += `Added ${name} for ${price} to the cart.\n`;
      } 
      else if(element.classList.contains('checkout')){
         const productsList = Array.from(products).join(', ');
         resultElement.textContent += `You bought ${productsList} for ${sum.toFixed(2)}.`;

          Array.from(shopingCardElement.getElementsByTagName('button'))
             .forEach(b => b.disabled = true);
      }
   }
}