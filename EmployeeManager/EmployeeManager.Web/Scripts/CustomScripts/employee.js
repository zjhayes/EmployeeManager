function searchEmployee() {
	var search = $("#searchString").val().trim();

	$.ajax({
		url: "Search",
		data: { searchString: search }
	}).done(function (data) {
		$("#employeeId").val(data.EmployeeId);
		$("#firstName").val(data.FirstName);
		$("#middleName").val(data.MiddleName);
		$("#lastName").val(data.LastName);
		$("#dateHired").val(data.DateHiredString);
		$("#birthDate").val(data.BirthDateString);
		$("#salary").val(data.Salary);
		$("#recurrence").val(data.Recurrence);
		$("#jobTitle").val(data.JobTitle);
		$("#department").val(data.Department);
		$("#availability").val(data.Availability);
	});
}

function updateEmployee() {
	var employeeId = $("#employeeId").val();
	var firstName = $("#firstName").val();
	var middleName = $("#middleName").val();
	var lastName = $("#lastName").val();
	var dateHired = $("#dateHired").val();
	var birthDate = $("#birthDate").val();
	var salary = $("#salary").val();
	var recurrence = $("#recurrence").val();
	var jobTitle = $("#jobTitle").val();
	var department = $("#department").val();
	var availability = $("#availability").val();

	$.ajax({
		url: "UpdateEmployee",
		dataType: "json",
		data: {
			EmployeeId: employeeId,
			FirstName: firstName,
			MiddleName: middleName,
			LastName: lastName,
			DateHired: dateHired,
			BirthDate: birthDate,
			Salary: salary,
			Recurrence: recurrence,
			JobTitle: jobTitle,
			Department: department,
			Availability: availability
		}
	}).done(function (data) {
		if (data) {
			$("#successMessage").removeClass("hidden")
				.addClass("visible");
		} else {
			$("#errorMessage").removeClass("hidden")
				.addClass("visible");
		}
	});
}