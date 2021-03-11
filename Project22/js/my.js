$(document).ready(function(){
    $('#nav').localScroll(800);
    
    //.parallax(xPosition, speedFactor, outerHeight) options:
    //xPosition - Horizontal position of the element
    //inertia - speed to move relative to vertical scroll. Example: 0.1 is one tenth the speed of scrolling, 2 is twice the speed of scrolling
    //outerHeight (true/false) - Whether or not jQuery should use it's outerHeight option to determine when a section is in the viewport
    $('#opening').parallax("50%", 0.1);
    $('#opening .bg').parallax("50%", 0.3);
    $('#second').parallax("50%", 0.1);
    $('#second .secondbg').parallax("70%", 0.8)
	$('#third').parallax("50%", 0.3);

	var elem = document.getElementById('mySwipe');
	window.mySwipe = Swipe(elem, {
	  auto: 3000,
	  continuous: true
	});
})