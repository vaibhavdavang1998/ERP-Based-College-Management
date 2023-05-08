<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://fonts.google.com/specimen/Montserrat?selection.family=Montserrat:400,600,700" rel="stylesheet"/>
    <link href="css/lucidEdge.css" rel="stylesheet" />
    <script src="js/jquery-1.8.2.min.js"></script>

    <link href="css/glider.css" rel="stylesheet" />
    <script src="js/glider.js"></script>
    
    <script src="js/animate-headline.js"></script>  
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/> 

</head>
<body>
     <!-- Header starts -->
    <div id="header">
        <div id="Home" class="pad_TB_5 width100">
            <div class="col_1140 posRelative">
               <div class="logoContainer">
                   <a href="<%=rootPath %>" title="" >
                        <img alt="" class="logoBig" src="images/logo.png" />
                   </a>
                </div>
                <div class="float_right">
                    <span class="space35"></span>
                    <h1 class="large themeClrPrimary">Sanjeevan Engineering and Technology Institute, panhala, kolhapur</h1>
                </div>
                <%--<a href="tel:+919372127001" id="call">+91 9372127001</a>
                <a href="tel:+919372127001" id="callResp"></a>
                <div id="topNavPanel">
                    <ul id="topNav">
                        <li><a href="<%=rootPath %>">Home</a></li>
                        <li><a href="about-us">About Us</a></li>
                        <li><a href="services">Services</a></li>
                        <li><a href="portfolio">Portfolio</a></li>
                        <li><a href="blog">Blog</a></li>
                        <li><a href="enquiry">Enquiry</a></li>
                        <li><a href="contact-us">Contact Us</a></li>
                    </ul>
                </div>
                <a id="navBtn" ></a>--%>
                <div class="float_clear"></div>
            </div>
        </div>
</div>
<!-- Header ends -->

<!-- banner start -->
<section class="hero-section clip">
    <div class="banner">
        <div class="bannerOverlay">
            <div class="hero-section__wrap">
                <span class="space50"></span>
                <span class="space50"></span>
                <span class="space50"></span>
                <div class="txtCenter extra-large">
                    <h1 class="title__heading clrWhite">
                        <strong class="hero-section__words">
                            <span class="title__effect is-visible">Computer</span>
                            <span class="title__effect">Mechanical</span>
                            <span class="title__effect">Civil</span>
                            <span class="title__effect">Electrical</span>
                            <span class="title__effect">IT</span>
                        </strong>
                        <span>Engineering</span>
                    </h1>      
                </div>
            </div>
        </div>
    </div>
</section>
<!-- banner end -->  

<!-- about-us start -->
<span class="space50"></span>
    <div class="col_1140 txtCenter">
        <h2 class="extra-large bold clrPrimaryTxt">About us</h2>
        <span class="space30"></span>
        <p class="clrRegTxt lineHt">In 1992, he has established the Holy-wood Academy to impart best quality education at Primary, Secondary, Higher-Secondary, Graduation and Post-graduation in various disciplines.

With a batch of only 7 students, he layed the foundation stone of SANJEEVAN KNOWLEDGE CITY by starting Sanjeevan Public School in 1994.Today, there are more than 2500 students studying from all over the country from KG to PG. Sanjeevan Engineering & Technology Institute (SETI) is long cherished dream of Founder-Chairman Mr. P. R. BHOSALE, an Educationalist having experience about two decades. His aim is to impart quality education to the students from nook and corner of the country. No doubt, Sanjeevan Engineers will be the best professionals with added values of Indian Heritage.  </p>
        <span class="space30"></span>
        
    </div>
<span class="space50"></span>
<!-- about-us end -->
<!--services starts -->
<div class="bgWhitef8">
    <span class="space50"></span>
    <div class="col_1140 txtCenter">
        <h2 class="extra-large bold clrPrimaryTxt">Our Programs</h2>
        <span class="space30"></span>
        <div class="col_1_3 txtCenter">
            <div class="pad_10">
                
                <span class="space20"></span>
                <h3 class="large bold clrSecTxt">Diploma Courses</h3>
                <span class="space20"></span>
            </div>
        </div>
        <div class="col_1_3 txtCenter">
            <div class="pad_10">
                
                <span class="space20"></span>
                <h3 class="large bold clrSecTxt">Under Graduated Courses</h3>
                <span class="space50"></span>
            </div>
        </div>
        <div class="col_1_3 txtCenter">
            <div class="pad_10">
                
                <span class="space20"></span>
                <h3 class="large bold clrSecTxt">Post Graduated Courses</h3>
                <span class="space50"></span>
            </div>
        </div>
        <div class="float_clear"></div>
        <span class="space30"></span>
        <%--<a href="services" title="Read more about other services provided by Lucid Edge Tech Serv" class="button btnGreen">More Services</a>--%>
    </div>
    <span class="space50"></span>
</div>
<!--services ends -->
<!--Like what we offer starts-->
<div class="offerBanner">
    <span class="space50"></span>
    <div class="col_1140 txtCenter">
        <h2 class="extra-large bold clrWhite">Our Families</h2>
        <span class="space30"></span>
        <div class="col_1_3">
            <div class="pad_10">
                <h3 class="clrWhite extra-large">Our Students</h3>
                <span class="space20"></span>
                <h2 class="clrWhite extra-large">1000+</h2>
            </div>
        </div>
        <div class="col_1_3">
            <div class="pad_10">
                <h3 class="clrWhite extra-large">Our Teacher</h3>
                <span class="space20"></span>
                <h2 class="clrWhite extra-large">145+</h2>
            </div>
        </div>
        <div class="col_1_3">
            <div class="pad_10">
                <h3 class="clrWhite extra-large">courses</h3>
                <span class="space20"></span>
                <h2 class="clrWhite extra-large">40+</h2>
            </div>
        </div>
        <div class="float_clear"></div>
        
        <span class="space30"></span>
        
    </div>
    <span class="space50"></span>
</div>
<!--Like what we offer ends-->
<!--Time table-->
<%--<div class="col_1140 txtCenter">
    <h2 class="extra-large bold clrPrimaryTxt">Our Time table</h2>
    <span class="space30"></span>
     <%=GetLatestTimeTable() %>
</div>--%>

<!--Nav button-->
<script type="text/javascript" >
    $("#navBtn").click(function () {
        $("#topNavPanel").slideToggle("2000");
    });
</script>

<!--Slider-->
<script integrity="sha256-BbhdlvQf/xTY9gja0Dq3HiwQF8LaCRTXxZKRutelT44=" crossorigin="anonymous" type="text/javascript"></script>
 <script type="text/javascript">
     var gliders = $('.slide').glider();
</script>

<!--Fixed header-->
<script>
    $(window).scroll(function () {
        var header = $('#header'),
            scroll = $(window).scrollTop();

        if (scroll) header.addClass('fixed');
        else header.removeClass('fixed');
    });
</script>
</body>
</html>
