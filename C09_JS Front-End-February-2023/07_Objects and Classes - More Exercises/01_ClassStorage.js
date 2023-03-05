class Storage{
    constructor(capacity){
        this.capacity = capacity;
        this.storage = [];
    }

    get totalCost() {
        return this.storage.reduce((sum, currentProduct) => {
            sum += currentProduct.price * currentProduct.quantity;
            return sum;
        }, 0)
    }

    addProduct(product){
        if(this.capacity >= product.quantity){
            this.storage.push(product);
            this.capacity -= product.quantity;
        }
    }

    getProducts(){
        return this.storage
            .map(p => JSON.stringify(p))
            .join('\n');
    }
}