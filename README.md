https://hackmd.io/@DfW-a1NDRXyxlnXCYWGb6Q/SJkNpigD_#

# 屋塔房課程

## 遊戲模型
> [主角模型](https://assetstore.unity.com/packages/3d/characters/humanoids/humans/fantasy-chess-rpg-character-arthur-160647) 
> [怪物模型](https://assetstore.unity.com/packages/3d/characters/humanoids/fantasy-monster-skeleton-35635)
> [場景模型](https://assetstore.unity.com/packages/3d/environments/fantasy/fantasy-forest-environment-free-demo-35361)
> [特效](https://assetstore.unity.com/packages/vfx/particles/cartoon-fx-free-109565)
> [讀取](https://assetstore.unity.com/packages/2d/gui/icons/animated-loading-icons-47844)

## VS CODE 套件
> [Bracket Pair Colorizer](https://marketplace.visualstudio.com/items?itemName=CoenraadS.bracket-pair-colorizer) 
> [indent-rainbow](https://marketplace.visualstudio.com/items?itemName=oderwat.indent-rainbow) 
> [Debugger for Unity](https://marketplace.visualstudio.com/items?itemName=Unity.unity-debug) 
> 
## 主要動畫 
* Idle、Run、Attack、Damage、Death

## 主要指令

**監測鍵盤**
>  float h = Input.GetAxis("Horizontal");
>  float v = Input.GetAxis("Vertical");
>  Input.GetKeyDown(KeyCode.Space)

**角色移動及旋轉**
> velocity = new Vector3(0, 0, v);
> velocity = transform.TransformDirection(velocity);
> transform.localPosition += velocity * Time.fixedDeltaTime;
> transform.Rotate(0, h * rotateSpeed, 0);

**動畫控制及偵測**
> `Animator`.SetBool("Attack", true);
> `Animator`.SetFloat("Speed", 5);
> `Animator`.GetCurrentAnimatorStateInfo(0).IsName("Run")

**怪物自動尋路**
> Vector3.Distance(transform.position,     `GameObject`.transform.position);
> `NavMeshAgent`.SetDestination(`GameObject`.transform.position);

**enum狀態**
>enum SkeletonStatus
> {
>     ATTACK, // 遊戲準備
>     MOVE, // 遊戲開始
>     Damage   // 遊戲結束
> }
> SkeletonStatus gameStatus;