# How To Use The Scripts Here

## To Make a Gun
### This requires Gun.cs, Bullet.cs and Health.cs

1) Firstly, you need to attach your gun to the player. This is simply done by positioning it and making it the child of the camera.

2) We now need to create an empty game object. This is where the bullets will come out of the gun. If, when the set up is done, the bullets disappear almost instantly this is because it is too close and they are touching the gun. Attach the Gun script to this empty game object.

3) We now need a bullet prefab. This is any bullet model with the Bullet.cs script attached, a collider (set as a trigger) and a rigid body. The default body settings are fine. You will need to add a tag. I suggest you call it Ammo

4) Return to the gun and drag the bullet prefab to the correct variable.

5) you can now change the nature of the cup of the weapon, it’s damage, weather it is automatic or semi-automatic, and its cool down between every shot.

6) If you test the game, it should now be firing bullets.

7) You can now add health scripts to anything that can be shot. Set the tag variable to whatever the tag that you added to the bullets was, The default being Ammo.

