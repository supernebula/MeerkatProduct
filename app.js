// JavaScript source code
var co = require("co");
console.dir(co);



// var Gen = function* (p)
// {
//   var a = yield x => x + p;
//   console.log("a= "+ a);
//   var b = yield y => y + p;
//   console.log("b= "+ b);
//   var c = yield z => z + p;
//   console.log("c= "+ c);
// }
// var gen = Gen(1);
// var reslut = gen.next();
// gen.next(fun1(2));
// gen.next(fun1(2));

function delay(time) {
    return function (fn) {
        setTimeout(function () {
            fn(time);
        }, time)
    }
}

(function test1(bool) {
    if (!bool) return;
    console.log("Test1:---------------------------------------------")
    
    console.time("test1");
    var func1 = delay(3000);
    func1(function (time) {
        console.timeEnd("test1");
    });
})(false);


function delay2(time) {
    return function (fn) {
        setTimeout(function () {
            fn();
        }, time)
    }
}


// function coTest(){
//   console.log("Test2");
//   console.time("Test2");
//
//
//
// }
// coTest();
console.time("Test2");
co(function* () {
    yield delay2(200);
    yield delay2(1000);
    yield delay2(500);
}).then(function () {
    console.log("test2");
    console.timeEnd("Test2"); // print 1: 1702.000ms
});
