# MillionaireGame
Making web site with a questions game where users create the questions+answers and play the game.

## Logic
- A user requires a login to be able to make Questions and Answers;
- Each Question is associated to 1 Category and 4 possible Answers;
- Anonymous users can play the game;
- Anonymous users game win count should be stored with cookies and updated to the database if they create an account;
- The users must be evaluated per Question and assigned Answers made;
- The Questions and Answers created must be reviewed in a queue for Admin users to approve or disapprove;
- Admins can create or assign Categories if users haven't done so.

## Roadmap
1. Implement login and user restrictions to Admin pages;
2. Create game page and logic for it (a game has a total of 15 questions and 60 answers (15*4));
3. Integrate the queue (Azure queue would be nice);
4. Add evaluation of users per the Questions and Answers they create;
5. Update the UI/UX.

## Possible Extras
1. Create a ranking system for users based on evaluation of Question/Answers and games won/lost;
2. Create an achievment system for users;
3. Add automation to the disapprove/approve of Question and Answers (maybe some sort of AI to filter the Questions, like any Question with slurs should go to the NSFW Category);
4. Questions badly evaluated by players should be reviewed by Admins, and the users that created those Questions should be notified of actions taken.
