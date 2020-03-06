var http = require('http');
var url = require('url') ;
sys = require('sys');
var audienceClients = [];
var audienceServerPort = 44456;
var maxDroppedFrames=5;

//var username = 'mobi';
//var password = '2o2oImaging';
//var auth = 'Basic ' + new Buffer(username + ':' + password).toString('base64');

process.on('uncaughtException', function (err) {
  console.error(err);
  console.log("Node NOT Exiting...");
});


http.createServer(function (req, res) {
 
var srcURL=req.url;
srcURL=srcURL.substring(1);
srcURL.replace(/(\r\n|\n|\r)/gm,"");
srcURL = url.parse(srcURL);
 
 //var auth=srcURL.auth;
 //sys.puts('authentication' + srcURL.auth);

 var auth = 'Basic ' + new Buffer(srcURL.auth).toString('base64');
//var temphostname='http://mobi:2o2oImaging@' + srcURL.hostname;
//sys.puts('temphostname' + temphostname);
////Create request to client

var srcClient = http.createClient(srcURL.port || 80, srcURL.hostname);

srcClient.on('error', function(err) {
    sys.puts('unable to connect to ' + srcURL.hostname);
});

srcClient.addListener('error', function(connectionException){
    sys.log(connectionException);	
});

	
var request = srcClient.request('GET', srcURL.pathname + (srcURL.search ? srcURL.search : ""),
  { 'host': srcURL.hostname, 'Authorization': auth});  //temphostname
	
	request.end();
	res.socket.on('close', function () {		
        request.end();		
      });
	
	res.on('error', function () {		
        request.end();
		sys.put('request end error');
      });

	request.on('error', function (srcError) 
	{    			
		sys.log(srcError);
		sys.put('srcError' +srcError);
     });
	 
	 request.on('uncaughtException', function (err) {
				
				console.error(err.stack);
				console.log("Node NOT Exiting...");
			});

	request.addListener('response', function(response){
    		
		req.socket.on('close', function () {
      		// console.log('exiting client!');
			response.end();
			response.destroy();
			request.end();	
			sys.puts('response destroyed ');
			global.gc();

		});
			req.on('uncaughtException', function (err) {
				response.end();
				response.destroy();
				request.end();	
				console.error(err.stack);
				console.log("Node NOT Exiting...");
			});
		res.writeHead(200, response.headers);  
			res.on('error', function (srcError) 
			{    		
				response.end();
				response.destroy();
				request.end();	
				sys.log(srcError);
				sys.puts('res srcError' +srcError);
				request.end();	
     		});
			res.on('uncaughtException', function (err) {
				response.end();
				response.destroy();
				request.end();	
				console.error(err.stack);
				console.log("Node NOT Exiting...");
			});
			res.socket.on('error', function (srcError) 
			{    			
				response.end();
				response.destroy();
				request.end();
				sys.log(srcError);
				sys.puts('res socket srcError' +srcError);
				request.end();	
     		});
			response.socket.on('error', function (srcError) 
			{  
				response.end();
				response.destroy();
				request.end();
				sys.log(srcError);
				sys.puts('res socket srcError' +srcError);
				request.end();	
     		});
			response.on('error', function (srcError) 
			{  
				response.end();
				response.destroy();
				request.end();
				sys.log(srcError);
				sys.puts('response srcError' +srcError);
				request.end();	
     		});
			response.useChunkedEncodingByDefault = false;
    		response.addListener('data', function(chunk){ 
				if (chunk !== null && chunk !== undefined )
				{
						res.write(chunk); 
				}					
    		});
    		response.addListener('end', function(){
        	request.end();				
			res.end();  
			response.end();
			response.destroy();
    		});
	});

	
	
}).listen(8088);