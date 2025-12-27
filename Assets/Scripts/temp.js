

function checkIsWin(guess, word) {
    if (guess === word) {
        console.log('won')
        return true
    } else if (guess === "s") {
        console.log('s')
    } else {
        console.log('not won')
        return false
    }
}
let guess = 'a';
let word = 'b';

function gameloop() {
    let array = [1, 2, 3, 4]
    if (checkIsWin(word, guess)) {
        console.log('game over')
        return
    }

    for (let index = 0; index < array.length; index++) {
        if (0) {
            continue
        }
        if (1) {
            break
        }
        const element = array[index];
        /// 
        console.log(element)
    }

}