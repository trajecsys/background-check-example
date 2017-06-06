# Background Check API #

To send a background update, you POST a x-www-form-urlencoded request to **https://www.trajecsys.com/programs/api/verification/ProvideData.ashx**

The following parameters are mandatory:

* apikey - We will give you this
* provider - You probably want "background"
* status - See status choices below
* status_date - We will try to parse almost any unambiguous format you provide.  We encourage an ISO-compliant format like `2008-11-01T19:35:00.0000000-07:00`
* program_code - Each program has a unique code that will be negotiated with you
* student_email - The email address of the student being updated.  We match all our background updates by student

The status code options are:

* InProgress - Informs us the background check has begun
* Complete - Informs us of successful completion with no review needed.
* Alert - Informs us that review is required by the program, or some failure criteria has been hit on the review
* Cancelled - Informs us that you will not be completing the review (probably due to student cancellation)

If you get a "200" response with some informational JSON, your update succeeded.  Otherwise, you will receive a 4xx or 5xx code with a description of what went wrong.

### Who do I talk to? ###

You can contact me at cjay@trajecsys.com