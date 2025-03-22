const fetchFile = async (url, contentType) => {
	const response = await fetch(url, {
		headers: {
			'Content-Type': contentType,
		},
	});

	if (!response.ok) {
		throw new Error(
			`Network response was not ok: ${response.status} ${response.statusText}`,
		);
	}
	return await response.blob();
};