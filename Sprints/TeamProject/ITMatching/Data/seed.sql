--Insert OS Tags
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('OS', 'Windows 7');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('OS', 'Windows 8');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('OS', 'Windows 10');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('OS', 'MacOS');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('OS', 'Linux');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('OS', 'Other');

--Insert Hardware Service Tags
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Hardware');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Motherboard');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'CPU');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'CPU Fan');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Graphics Card');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Sound Card');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Audio DAC');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'RAM');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'HDD');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'SSD');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Power Supply');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Disc Drive');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Computer Case Fan');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'USB Port');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Aux Port');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Monitor');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Speaker');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Headphones / Headset');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Bluetooth Device');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Microphone');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Webcam');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Mouse');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Keyboard');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Drawing Tablet');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Cell Phone');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', 'Conventional Printer');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Hardware', '3D Printer');

--Insert Software Service Tags
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Software');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'BIOS');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'OS Settings');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Command Line');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Microsoft Edge');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Safari');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Mozilla Firefox');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Google Chrome');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Opera Browser');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Other Web Browser');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Local File Manager');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Microsoft Office Suite');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Adobe Creative Cloud');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Anti-virus software');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Software', 'Google Workspace');

--Insert Network Service Tags
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'Network');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'Wi-Fi Connection');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'Wired Connection');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'IPv4');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'IPv6');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'Router');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'Modem');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'Gateway');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'DNS');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'Ports');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'TCP');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'UDP');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'ICMP');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'Firewall');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'HTTP');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'URL');

--Insert Preferred Method of Communication Tags
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('CommunicationMethod', 'Text');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('CommunicationMethod', 'Voice Call');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('CommunicationMethod', 'Video Call');
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('CommunicationMethod', 'Screenshare');

--Insert FAQ Page Questions and Answers
INSERT INTO [FAQ](Question,Answer) VALUES('What is the difference if I sign up as a Client compared to if I sign up as an Expert?', 'As a client, you can request help from an Expert to assist you in solving your IT issue. An Expert can choose a matching Client they want to assist with their IT issue.');
INSERT INTO [FAQ](Question,Answer) VALUES('Can I change my schedule at any time?', 'Yes. You can change your schedule by heading over to your account profile page and selecting the Personal Info tab.');
INSERT INTO [FAQ](Question,Answer) VALUES('If I am already registered as an Expert, do I have to sign up as a Client to send a help request to another Expert?', 'Yes. You must create a separate account (i.e. register as a Client) to receive help from another Expert.');
INSERT INTO [FAQ](Question,Answer) VALUES('What do I do if I am unable to find my verification email?', 'Make sure to check all your folders including your spam folder in your email inbox. You may also go into the login page and click on the Resend Email Confirmation link to receive another verification link.');
INSERT INTO [FAQ](Question,Answer) VALUES('As a Client, can I submit multiple help requests at the same time?', 'No, you can only submit one help request at a time. Attempting to submit another help request will close the previous one you made.');
INSERT INTO [FAQ](Question,Answer) VALUES('What do I do if I am unable to find my verification email?', 'Make sure to check all your folders including your spam folder in your email inbox. You may also go into the login page and click on the Resend Email Confirmation link to receive another verification link.');
INSERT INTO [FAQ](Question,Answer) VALUES('As an Expert, can I accept multiple clients to assist?', 'No, you may only choose to help out one client at a time.');
INSERT INTO [FAQ](Question,Answer) VALUES('Can I delete my account?', 'Yes. You can head over to your account profile (link in the top-right hand corner of the page) and select the Delete Account tab to enter the page to remove your account.');
INSERT INTO [FAQ](Question,Answer) VALUES('I forgot my password can I reset it?', 'Yes. Head over to the login page and select the Forgot your password? link. Enter in your email so that can send you a link to change your password.');
INSERT INTO [FAQ](Question,Answer) VALUES('What do I do if my question is not answered here?', 'You can contact us by email at itmatching@outlook.com and tell us about your question.');

--Insert Test Meeting objects to test Expert Waiting Room
