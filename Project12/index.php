
<!DOCTYPE html>
<!--[if lt IE 7 ]><html class="ie ie6" lang="en"> <![endif]-->
<!--[if IE 7 ]><html class="ie ie7" lang="en"> <![endif]-->
<!--[if IE 8 ]><html class="ie ie8" lang="en"> <![endif]-->
<!--[if (gte IE 9)|!(IE)]><!--><html lang="en"> <!--<![endif]-->
<head>

  <!-- Basic Page Needs
  ================================================== -->
  <meta charset="utf-8">
  <title>Jon D Jones Contact Me</title>
  <meta name="description" content="">
  <meta name="author" content="">

  <!-- Mobile Specific Metas
  ================================================== -->
  <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

  <!-- CSS
  ================================================== -->
  <link rel="stylesheet" href="./css/base.css">
  <link rel="stylesheet" href="./css/skeleton.css">
  <link rel="stylesheet" href="./css/layout.css">
  <link rel="stylesheet" href="captcha/captcha.css" >
  <link rel="stylesheet" href="./css/style.css" media="all" />
      
  <!--[if lt IE 9]>
    <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
  <![endif]-->

  <!-- Favicons
  ================================================== -->
  <link rel="shortcut icon" href="images/favicon.ico">
  <link rel="apple-touch-icon" href="images/apple-touch-icon.png">
  <link rel="apple-touch-icon" sizes="72x72" href="images/apple-touch-icon-72x72.png">
  <link rel="apple-touch-icon" sizes="114x114" href="images/apple-touch-icon-114x114.png">

</head>
<body>



  <!-- Primary Page Layout
  ================================================== -->

  <!-- Delete everything in this .container and get started on your own site! -->

  <div class="container">

    <div class="eight columns">
      <div id="form-div">
        <h3>Want To Discus Things Further ?</h3>
        <p>I always have a little capacity to take on new project so feel free to get it touch so we can talk about your idea.  Just fill out my fancy form below or email me at jon@jondjones.com and I’ll reply back as soon as possible. Cheers!</p>

        <p class="featureimage">
            <img src="./images/image1.jpg" />
        </p>

        <p>
          I’m based in Southampton on the South coast of England but I work for clients all over the world. I use a very simple process that will allow us to get your project moving at light speed!
        </p>
    </div>
    </div>

    <div class="eight columns">

      <div id="form-div">

        <h3>Get In Contact</h3>

         <form id="register-form" data-validate="parsley" action="captcha/captcha.php" method="post">

            <p class="fieldgroup">

              <div class="formcontrol">

                <label for="name" id="placeholder">Name</label>
                <input name="name" type="text" class="text-input" id="name" data-required="true" />

              </div>

            </p>

            <p class="fieldgroup">

              <div class="formcontrol">
                <label for="email" id="placeholder">E-mail</label>
                <input name="email" type="text" class="text-input" id="email" data-required="true" data-type="email" />
              </div>

            </p>

            <p class="fieldgroup">

              <div class="formcontrol">
                <label for="password" id="placeholder">Password</label>
                <input type="text" name="password" id="password" class="password" data-required="true" /><meter value="0" id="PassValue" max="100"></meter>
              </div>
            </p>

            <p class="fieldgroup">
              <div class="formcontrol">
              <label for="comment" id="textareaplaceholder">Comments</label>
              <textarea name="comment" class="text-input" id="comment"></textarea>
            </div>
            </p>
            <p class="fieldgroup">
              <div class="ajax-fc-container"></div>
            </p>
            <p class="fieldgroup">
              <input type="submit" value="Send" />
            </p>

        </form>

      </div>

    </div>

  </div>

  <script src="./js/jquery.min.js" type="text/javascript"></script>
  <script src="./js/parsley.js" type="text/javascript"></script>
  <script src="./js/jquery.infieldlabel.min.js" type="text/javascript"></script>
  <script src="./js/jquery.backstretch.min.js" type="text/javascript"></script>
  <script src="./js/jquery.complexify.js" type="text/javascript"></script>
  <script src="./js/jquery-ui.min.js" type="text/javascript" ></script>
  <script src="./captcha/jquery.captcha.js" type="text/javascript" ></script>

  <script>

      $(document).ready(function(){

          $("label").inFieldLabels();

          $.backstretch("./images/background.jpg");


          $("#password").complexify({}, function (valid, complexity) {
                document.getElementById("PassValue").value = complexity;
            });

          $(function() {
            $(".ajax-fc-container").captcha({formId: "register-form"});
          });
      });

  </script>

</body>
</html>