mandrill-inbound-classes
========================

This is the set of classes that Surveylitics (http://survyelitics.com) uses to handle inbound emails with Mandrill (http://mandrillapp.com).

They are designed to be used with Json.NET, like this:

public ActionResult HandleMandrillWebhook(FormCollection fc)
{
	string json = fc["mandrill_events"];

	var events = JsonConvert.DeserializeObject<IEnumerable<Mandrill.MailEvent>>(json);
	foreach (var event in events)
	{
		var message = event.Msg;
		// ... Do stuff with email message here...
	}
	
	// MUST do this or Mandrill will not accept your webhook!
    return new HttpStatusCodeResult((int)HttpStatusCode.OK);
}