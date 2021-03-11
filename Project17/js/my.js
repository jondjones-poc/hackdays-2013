function IsNumeric(n){
    return !isNaN(n);
} 

$(function(){
	
    $("#getit").click(function() {

        $("#results").empty();
        $("#winning").empty();
        
        var intRegex = /^\d+$/;

        var usersNumbers = [];

        var one = $('#numberone').val();
        if(intRegex.test(one)) {
            var one = parseInt(one);
            if (one > 0 && one <= 36)
            {
                usersNumbers.push(one);
            }
        }
        
        var two = $('#numbertwo').val();
        if(intRegex.test(two)) {
            var two = parseInt(two);
            if (two > 0 && two <= 36)
            {
                usersNumbers.push(two);
            }
        }

        var three = $('#numberthree').val();
        if(intRegex.test(three)) {
            var three = parseInt(three);
            if (three > 0 && three <= 36)
            {
                usersNumbers.push(three);
            }
        }

        var four = $('#numberfour').val();
        if(intRegex.test(four)) {
            var four = parseInt(four);
            if (four > 0 && four <= 36)
            {
                usersNumbers.push(four);
            }
        }

        var five = $('#numberfive').val();
        if(intRegex.test(five)) {
            var five = parseInt(five);
            if (five > 0 && five <= 36)
            {
                usersNumbers.push(five);
            }
        }

        var six = $('#numbersix').val();
        if(intRegex.test(six)) {
            var six = parseInt(six);
            if (six > 0 && six <= 36)
            {
                usersNumbers.push(six);
            }
        }

        var checkForDups = _.uniq(usersNumbers);
        if (usersNumbers.length != 6 || checkForDups.length != 6)
        {
            alertify.alert('You must enter six unqiue numbers... 36 and under... don\'t try and cheat me!');
        }
        else
        {
            var winningNumbers = [];
            for (var i = 0; winningNumbers.length <= 5; i++) {
                
                var number = Math.floor(Math.random()*36)  + 1;
                var containsUnique = _.difference( winningNumbers, [number]);

                if (containsUnique.length == winningNumbers.length)
                {
                    winningNumbers.push(number);
                }
            }

            var array =_.sortBy(winningNumbers, function(num){
                return num;
            });

            _.each(array, function(num) { 

                var display = num;
                if (display.toString().length == 1) {
                    display = "0" + display.toString();
                }

                $( "#results" ).append( $( "<li> " + display +" </li>" ) );
            }, array);


            var matchingNumbers = _.difference(usersNumbers, winningNumbers);
            var difference = parseInt(6 - matchingNumbers.length);
            if (difference == 6)
            {
                alertify.alert('You have won the lottery!');
            }
            else
            {
                $("#winning").append('You have ' + difference + ' matching numbers');
            }
        }


        return false;
    });
    
    $("input[type=text]").each(function(){
        $(this).data("first-click", true);
    });
    
    $("input[type=text]").focus(function(){
       
        if ($(this).data("first-click")) {
            $(this).val("");
            $(this).data("first-click", false);
            $(this).css("color", "black");
        }
        
    });
	
});