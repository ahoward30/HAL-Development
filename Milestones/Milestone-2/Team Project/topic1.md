IT Help Matching
==================================================

A service designed to match users with IT professionals for online consultations based upon the user’s issues. Both users and professionals would have their own portal to log-in from, with users being prompted to describe hardware or software issues and professionals being prompted to list technical specialties. The service would take into account operating systems, hardware devices, and common applications such as Microsoft Word. Our service would take the pool of users and pool of professionals and calculate which professional is best suited for a particular user’s hardware or software issue, and then allow for them to participate in a video call consultation.

Unlike other services, our matching service is not tied to a specific company or product, and the matching service itself works to ensure users will be guaranteed to be matched with an individual who specializes in addressing whatever IT issue they may be facing without the need to be redirected or put on hold after calling. Other IT organizations with no specific company or product backing may connect users to support reps with a general knowledge of IT support, but with no guarantee that they have direct experience with the exact issue that the user is facing at that moment. These two factors make our service incredibly flexible and dynamic for addressing the needs of potential users. With a sufficiently large pool of professionals on the site, a user can feel confident that the website can match them with a specialist who could work them through any possible issue they may be facing, and that said specialist likely has encountered and fixed a very similar issue before.

Major features of our service involve:
* A matchmaking feature that connects users to specialists based upon their specific input
* User and professional accounts to keep track of their information
* Ability to connect for video calls or text chat

Alongside using the Azure service, our project will be relying on the use of an API for facilitating the video calling feature. WebRTC is an example of such an API that our team could utilize.
 
The algorithmic component of developing our service will primarily be based on quantifying how closely a user’s request matches the expertise of given professionals in the pool. The system has to account for the software environment, hardware, potential applications and the nature of the IT issue, and use this information to create a compatibility score that can be judged against scores compared to other professionals. In this case, the professional that yields the highest score when compared to the user’s issue will be selected to be matched with the user. The elements can not all be treated as equally as important when determining a score, and finding the balance of how to create a working algorithm from this information will be a large part of realizing the matchmaking system. We also need to adjust the algorithm to account for the volatility of real human users engaging on the site. For example, what happens if the professional with the highest compatibility score goes offline mid-matching making, but before the user and professional are connected? That is something we will need to account for.

I believe that this topic has a difficulty rating of 6. Making all of the little pieces come together to create a service that functions as we want it to will be a decent amount of work, but with the very real exception of the possibility for a video chatting feature, I don’t foresee any individual element as being too difficult. 


