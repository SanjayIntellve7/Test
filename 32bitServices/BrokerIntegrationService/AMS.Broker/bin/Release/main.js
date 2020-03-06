var fs = require('fs');
var formidable=require('formidable');

// Create the "uploads" folder if it doesn't exist
fs.exists(__dirname + '/uploads', function (exists) {
    if (!exists) {
        console.log('Creating directory ' + __dirname + '/uploads');
        fs.mkdir(__dirname + '/uploads', function (err) {
            if (err) {
                console.log('Error creating ' + __dirname + '/uploads');
                process.exit(1);
            }
        })
    }
});


exports.addImage = function(req, res, next) {

    console.log("upload");

     var form = new formidable.IncomingForm();
    form.parse(req, function(error, fields, files) {

	   var tmp_path = files.file.path;
	   console.log(tmp_path);

        var target_path = 'G:\\PhotoRepository\\MobAlert.jpg';
	   console.log(target_path);
        res.writeHead(200, {"Content-Type": "text"});
        res.write(tmp_path);
        res.end();
    });
    

};