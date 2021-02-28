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
INSERT INTO [Service](ServiceCategory,ServiceName) VALUES('Network', 'Port');
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
INSERT INTO [FAQ](Question,Answer) VALUES('How do I delete my account?', 'At the moment you cannot delete your account. Our staff is currently working on implementing this feature.');
INSERT INTO [FAQ](Question,Answer) VALUES('How do I create a post?', 'You must be a registered user to create a post. To create a post, hover over to the top-right corner and click on the create post button.');
INSERT INTO [FAQ](Question,Answer) VALUES('Where can I go to register for an account?', 'Click on the "Sign In" button at the top. Then click on the "create an account" link highlighted in blue.');
INSERT INTO [FAQ](Question,Answer) VALUES('Why are my posts not appearing on screen?', 'Try refreshing your page after submitting a post.');
INSERT INTO [FAQ](Question,Answer) VALUES('Can I register as both a user and an expert?', 'Yes, you may sign up as a user and an expert.');
INSERT INTO [FAQ](Question,Answer) VALUES('How do I cancel my meeting with an expert instructor?', 'At the moment you cannot cancel your account. Our staff is currently working on implementing this feature.');
INSERT INTO [FAQ](Question,Answer) VALUES('Can I choose more than one professional instructor?', 'No, you must select only one instructor of the options you are given.');
INSERT INTO [FAQ](Question,Answer) VALUES('Can I accept more than one client to instruct?', 'Yes, you certainly may. However, keep in mind not to have conflicting schedules with your clients.');
INSERT INTO [FAQ](Question,Answer) VALUES('As an expert, is there an option to let a user know why I specifically refused their request?', 'At the moment you cannot let the user know. Our staff is currently working on implementing this feature.');
INSERT INTO [FAQ](Question,Answer) VALUES('Can I select the same expert again without having to go through a match-up?', 'Yes, but at the moment you cannot. Our staff is currently working on fixing the bug to this feature.');
INSERT INTO [FAQ](Question,Answer) VALUES('Can I recieve notifications so that I may be informed if I got accepted by an expert?', 'At the moment you cannot recieve notifications to your account. Our staff is currently working on implementing this feature.');
INSERT INTO [FAQ](Question,Answer) VALUES('I forgot the scheduled meeting time with my expert instructor, where can I see this?', 'At the moment you cannot see your schedule. Our staff is currently working on implementing this feature..');
INSERT INTO [FAQ](Question,Answer) VALUES('Is there a fee to sign up as a client user?', 'No, there a no fees, as well as hidden fees, when you create a client account.');
INSERT INTO [FAQ](Question,Answer) VALUES('Is it possible not to be matched with an expert?', 'No. We have created a selection system in which you will be paired up with at least one expert.');
INSERT INTO [FAQ](Question,Answer) VALUES('My question is not answered here', 'Try contacting us by phone at 1-503-555-5555 or by email at HAL@example-email.com');
