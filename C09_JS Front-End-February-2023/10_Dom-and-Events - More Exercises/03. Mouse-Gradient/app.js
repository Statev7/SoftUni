function attachGradientEvents() {
    const btn = document.getElementById('gradient');
    const result = document.getElementById('result');

    btn.addEventListener('mousemove', move);
    btn.addEventListener('mouseout', out);

    function move(e){
        const value = Math.trunc((e.offsetX / (e.target.clientWidth - 1)) * 100);
        result.textContent = value + '%';
    }

    function out(){
        result.textContent = '';
    }
}