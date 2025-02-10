namespace CleancodersCom;

public class FrontPage
{
    public string Print()
    {
        return @"
<!DOCTYPE html>
<html lang=""en"">
<head>
  <meta charset=""UTF-8"" />
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
  <title>Clean Coders</title>
  <link rel=""preconnect"" href=""https://fonts.googleapis.com"" />
  <link rel=""preconnect"" href=""https://fonts.gstatic.com"" crossorigin />
  <link
    href=""https://fonts.googleapis.com/css2?family=Montserrat:wght@400;600&display=swap""
    rel=""stylesheet""
  />
</head>
<body>
  <!-- Header -->
  <header id=""top-header"">
    <div class=""container"">
      <div id=""logo""><a href=""/"">Clean Coders</a></div>
      <nav id=""navbar"">
        <a href=""#videos"">Courses</a>
        <a href=""#testimonials"">Testimonials</a>
        <a href=""/login"">Login / Sign-up</a>
      </nav>
    </div>
  </header>

  <section class=""welcome"">
    <div class=""container"">
      <div class=""tagline"">
        Training Videos for Software Professionals
      </div>
      <a class=""hero-button"" href=""#videos"">See All Courses</a>
    </div>
  </section>

  <section id=""videos"" class=""container"">
    <h2>Our Courses</h2>
    <div class=""video-list"">
      ${codecast}
<!--   
      <div class=""box"">
        <h3>Advanced TDD</h3>
        <p>Price: $59</p>
        <a class=""button"" href=""/cart/add/2"">Add to Cart</a>
      </div>
      <div class=""box"">
        <h3>Design Patterns</h3>
        <p>Price: $69</p>
        <a class=""button"" href=""/cart/add/3"">Add to Cart</a>
      </div>
      <div class=""box"">
        <h3>Refactoring Masterclass</h3>
        <p>Price: $79</p>
        <a class=""button"" href=""/cart/add/4"">Add to Cart</a>
      </div>
      <div class=""box"">
        <h3>Effective Debugging</h3>
        <p>Price: $39</p>
        <a class=""button"" href=""/cart/add/5"">Add to Cart</a>
      </div>
      <div class=""box"">
        <h3>Agile Methodologies</h3>
        <p>Price: $45</p>
        <a class=""button"" href=""/cart/add/6"">Add to Cart</a>
      </div>
-->
    </div>
  </section>

  <section id=""testimonials"" class=""container testimonials"">
    <h2>What Our Students Say</h2>
    <div class=""testimonial-list"">
      <div class=""testimonial"">
        ""The Clean Coders courses transformed my approach to coding.
        Highly recommended!""
      </div>
      <div class=""testimonial"">
        ""I love the practical insights and real-world examples provided in
        each course.""
      </div>
    </div>
  </section>

  <footer>
    <div class=""container"">
      <a href=""/contact"">Contact</a>
      <a href=""/blog"">Blog</a>
      <a href=""/privacy"">Privacy</a>
      <a href=""/terms"">Terms</a>
    </div>
  </footer>
</body>
</html>

<style>
    * {
      box-sizing: border-box;
      margin: 0;
      padding: 0;
    }
    body {
      font-family: 'Montserrat', sans-serif;
      background-color: #f4f4f4;
      color: #333;
      line-height: 1.6;
    }
    .container {
      width: 90%;
      max-width: 1200px;
      margin: auto;
      padding: 20px;
    }

    /* Header */
    header {
      background: linear-gradient(45deg, #0056b3, #0088ff);
      color: #fff;
      padding: 20px 0;
      box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }
    header .container {
      display: flex;
      justify-content: space-between;
      align-items: center;
      flex-wrap: wrap;
    }
    #logo a {
      font-size: 24px;
      font-weight: 600;
      text-decoration: none;
      color: #fff;
    }
    nav a {
      margin: 0 10px;
      text-decoration: none;
      color: #fff;
      font-weight: 500;
      transition: color 0.3s;
      padding: 8px 12px;
      border-radius: 4px;
    }
    nav a:hover {
      color: #ffc107;
      background: rgba(255, 255, 255, 0.2);
    }

    .welcome {
      background: linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)),
        url('https://d26o5k45lnmm4v.cloudfront.net/clean_code_banner.jpg')
          no-repeat center center/cover;
      padding: 100px 20px;
      text-align: center;
      color: #fff;
      border-radius: 8px;
      margin-bottom: 40px;
    }
    .welcome .tagline {
      font-size: 36px;
      font-weight: 600;
      margin-bottom: 20px;
    }
    .hero-button {
      display: inline-block;
      background: #ff9800;
      padding: 15px 30px;
      color: #fff;
      font-size: 18px;
      text-decoration: none;
      border-radius: 5px;
      transition: background 0.3s, transform 0.3s;
    }
    .hero-button:hover {
      background: #e68900;
      transform: scale(1.05);
    }

    #videos {
      margin-bottom: 40px;
    }
    #videos h2 {
      text-align: center;
      margin-bottom: 20px;
      font-size: 28px;
      color: #0056b3;
    }
    .video-list {
      display: flex;
      flex-wrap: wrap;
      gap: 20px;
      justify-content: flex-start;
    }
    .box {
      background: #fff;
      width: calc(33.333% - 20px);
      padding: 20px;
      border-radius: 8px;
      box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
      transition: transform 0.3s, box-shadow 0.3s;
      display: flex;
      flex-direction: column;
      align-items: center;
    }
    .box:hover {
      transform: translateY(-5px);
      box-shadow: 0 8px 16px rgba(0, 0, 0, 0.2);
    }
    .box h3 {
      font-size: 22px;
      color: #0056b3;
      margin-bottom: 10px;
      border-bottom: 2px solid #0088ff;
      padding-bottom: 5px;
      width: 100%;
      text-align: center;
    }
    .box p {
      font-size: 18px;
      margin-bottom: 20px;
      color: #333;
    }
    .button {
      margin-top: auto;
      display: inline-block;
      background: #0088ff;
      color: #fff;
      padding: 10px 20px;
      text-decoration: none;
      border-radius: 5px;
      transition: background 0.3s;
    }
    .button:hover {
      background: #0056b3;
    }

    .testimonials {
      background: #fff;
      padding: 40px 20px;
      border-radius: 8px;
      box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
      margin-bottom: 40px;
    }
    .testimonials h2 {
      text-align: center;
      margin-bottom: 20px;
      font-size: 28px;
      color: #0056b3;
    }
    .testimonial-list {
      display: flex;
      flex-wrap: wrap;
      gap: 20px;
      justify-content: center;
    }
    .testimonial {
      background: #f9f9f9;
      padding: 20px;
      border-radius: 8px;
      width: calc(50% - 20px);
      font-style: italic;
      text-align: center;
      position: relative;
    }
    .testimonial:before {
      content: ""“"";
      font-size: 40px;
      position: absolute;
      top: -10px;
      left: 10px;
      color: #ff9800;
    }
    .testimonial:after {
      content: ""”"";
      font-size: 40px;
      position: absolute;
      bottom: -10px;
      right: 10px;
      color: #ff9800;
    }

    footer {
      background: #333;
      color: #fff;
      padding: 20px 0;
      text-align: center;
    }
    footer a {
      color: #ffc107;
      margin: 0 10px;
      text-decoration: none;
      transition: color 0.3s;
    }
    footer a:hover {
      color: #ff9800;
    }

    @media (max-width: 992px) {
      .box {
        width: calc(50% - 20px);
      }
      .testimonial {
        width: calc(100% - 20px);
      }
    }
    @media (max-width: 600px) {
      header .container {
        flex-direction: column;
        align-items: flex-start;
      }
      .video-list {
        flex-direction: column;
      }
      .box {
        width: 100%;
      }
    }
  </style>
";
    }
}