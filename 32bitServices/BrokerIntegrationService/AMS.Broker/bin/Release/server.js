var express = require('express'),
    http = require('http'),
    path = require('path'),
    main = require('./main'),
    app = express();

process.on('uncaughtException', function (err) {
  console.error(err);
  console.log("Node NOT Exiting...");
});

app.use(express.static(path.join(__dirname, './uploads')));

app.post('/images', main.addImage); // endpoint to post new images

app.listen(8082, function () {
    console.log('PictureFeed server listening on port 8082');
});
