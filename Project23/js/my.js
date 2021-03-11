         
	var time = 1000;
	var ballheight = 260;
	var ballsize = 25;

		$('#shadow').css({
			'width':ballsize*1.5, 
			'height':ballsize/3, 
			'margin-left':-(ballsize*0.75),
			'display':'block', 
			'opacity':0.2, 
			'background-color': 'black'});

        function animUp() {
            $("#ball").animate({ top: "1px" }, time, "easeOutQuad", animDown);
        }

        function animDown() {
            $("#ball").animate({ top: "441px" }, time, "easeInQuad", animUp);
        }
		
		function ballshadow() {
				$('#shadow').animate({'width':ballsize, 'height':ballsize/4, 'margin-left':-(ballsize/2), 'opacity':1}, time, 'easeInQuad', function() {
					$('#shadow').animate({'width':ballsize*1.5, 'height':ballsize/3, 'margin-left':-(ballsize*0.75), 'opacity':0.2}, time, 'easeOutQuad', function() {
						ballshadow();
					});
				});
			}



        $(document).ready(function() {
            animUp();
			ballshadow();
        });