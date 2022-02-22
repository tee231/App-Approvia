

        // This delivers the form data to the endpoint URL. PLEASE SET A VALID ENDPOINT via 'endpoint' variable 
        document.getElementById("sendMessage").addEventListener("click", function() {
            doSomething();
         {

            chooseColor = "red"; // feedback color

            var mySparkPlugFeedback = document.getElementById("sparkPlugFeedback"); // the form object

            // below are the fields that collect information from the customer

            var mySPCustomerName = document.getElementById("customerName");

            var mySPCustomerEmail = document.getElementById("customerEmail");

            var mySPCustomerMessage = document.getElementById("customerMessage");

            var myFeedback = document.getElementById("feedback"); // the feedback display element

            var mySPFormDomainName = document.getElementById("_formDomainName"); // A hidden field to carry the form domain name

            var localDomainName = window.location.hostname; // the current domain name of the form

            if (!localDomainName) {

                mySPFormDomainName.setAttribute("value", "localhost"); // set the form domain name as 'localhost' by default

            } else {

                mySPFormDomainName.setAttribute("value", localDomainName); // set the form domain name where available

            }

            var mySPFormName = document.getElementById("_formName"); // A hidden field to carry the form name

            mySPFormName.setAttribute("value", mySparkPlugFeedback.name); // assign the form name hidden field to the actual form object name

            var message = "";

            if (!mySPCustomerName.value) {

                message = "Please provide your name!"; // validation to check for name and report where it is not provided

            }

            if (message == "" && !mySPCustomerEmail.value) {

                message = "Please enter your e-mail address!"; // validation to check for e-mail address and report where it is not provided if there was no previous error

            }

            if (message == "" && !mySPCustomerMessage.value) {

                message = "Please enter your message!"; // validation to check for message and report where it is not provided if there was no previous error

            }

            if (message == "" && (mySPCustomerMessage.value.length < 10 || mySPCustomerMessage.value.length > 500)) {

                message = "Your message must be between 10 and 500 characters in length!"; // validation to check for message size and report where it didn't fit specifications if there was no previous error

            }


            if (message == "") { //start processing form when there are no errors

                var formdata = new FormData(mySparkPlugFeedback); // get data from the form

                var endpoint = 'https://localhost:44321'; //change this to a valid endpoint;

                fetch(endpoint, {
                    method: 'post',
                    body: formdata,
                    mode: 'cors',

                }) // send the form data to a 'cors' enabled endpoint

                    .then((resp) => resp.json())
                    .then(function (data) {

                        // get the status report through 'data' variable formatted as JSON

                        if (data.success) {

                            chooseColor = "green"; // color when form submission was successful

                            mySparkPlugFeedback.reset(); // clear the form when the form was submitted

                        } else {

                            chooseColor = "red"; // color when form submission was NOT successful
                        }

                        message = data.message; // the report from the endpoint regarding the form submission

                        myFeedback.innerHTML = `<b>Status: </b><font color='` + chooseColor + `'>"` + message + `"</font>`; // the HTML element receives feedback from the endpoint

                    })
                    .catch(function (error) {

                        chooseColor = "red"; // color when attempts to submit the form were NOT successful

                        message = `Form Submission Failed: "` + error + `"`; // error message with actual report in 'error' variable

                        myFeedback.innerHTML = `<b>Status: </b><font color='` + chooseColor + `'>"` + message + `"</font>`; // the HTML element receives feedback from the endpoint

                    });

            } else {

                myFeedback.innerHTML = `<b>Status: </b><font color='` + chooseColor + `'>"` + message + `"</font>`; // the HTML element receives feedback from the endpoint

            }
        }
    });
