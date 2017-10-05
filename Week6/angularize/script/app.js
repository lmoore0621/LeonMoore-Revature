// (function () {
//     'use strict'
    
// function fizzBuzz() {

//     var fizz = "fizz";
//     var buzz = "buzz";
//     var fizzBuzz = "fizzBuzz";
//     var i = 1;

//     for (; i <= 100; i++) {
//         if (i % 3 === 0 && i % 5 === 0) {
//             console.log(fizzBuzz);
//         }
//         else if (i % 3 == 0) {
//             console.log(fizz);
//         }
//         else if (i % 5 == 0) {
//             console.log(buzz);
//         }
//         else {
//             console.log(i);
//         }
//     }
// }
// })();


var APP = (function () {
    'use strict'
    
    var person = {
        first: null,
        last: null
    }

    function person() {
        this.first = 'first',
        this.last = 'last'
    }

    function callSwapi() {
        var xhr = new XMLHttpRequest();

        xhr.open('get', 'http://swapi.co/api/people/1');
        xhr.onreadystatechange = function() {
            if (xhr.readyState === 4 && xhr.status === 200) {
                console.log(xhr.response);
            }
        }
        xhr.send();        
    }

    return {
        pLiteral: person,
        pConstructor: person,
        swapi: callSwapi
    }
})();

// var p = new APP.pConstructor();
// var p1 = APP.pLiteral;

// function NewPerson() {
//     this.middle = null;
// }

console.log(APP.swapi());
